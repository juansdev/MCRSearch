using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.SharedDtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class AppUserService: IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;
        protected ResponseAPI<AppUserLoginResponseDto> _responseApi;
        private readonly string _secretKey;

        public AppUserService(IAppUserRepository appUserRepository, IConfiguration config, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
            _responseApi = new ResponseAPI<AppUserLoginResponseDto>();
            _secretKey = config.GetValue<string>("ApiSettings:Secret");
        }

        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        public List<AppUserDto> GetUsers()
        {
            var listUsers = _appUserRepository.GetUsers().Result;
            var listUsersDto = new List<AppUserDto>();
            foreach (var list in listUsers)
            {
                listUsersDto.Add(_mapper.Map<AppUserDto>(list));
            }
            return listUsersDto;
        }

        /// <summary>
        /// Obtiene el usuario por ID.
        /// </summary>
        public AppUserDto GetUser(string userId)
        {
            var itemUser = _appUserRepository.GetUser(userId).Result;
            return _mapper.Map<AppUserDto>(itemUser);
        }

        /// <summary>
        /// Registra el usuario en la BD.
        /// </summary>
        public ResponseAPI<AppUserLoginResponseDto> Register(AppUserRegisterDto registerUserDto)
        {
            bool validateUserNameUnique = _appUserRepository.IsUniqueUser(registerUserDto.UserName).Result;
            if (!validateUserNameUnique)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("El nombre de usuario ya existe");
                return _responseApi;
            }
            var result = _appUserRepository.CreateUser(registerUserDto).Result;
            if (result.Succeeded)
            {
                if (!_appUserRepository.ExistRole("admin").GetAwaiter().GetResult())
                {
                    _appUserRepository.CreateRole("admin").GetAwaiter().GetResult();
                }
                if (!_appUserRepository.ExistRole("user").GetAwaiter().GetResult())
                {
                    _appUserRepository.CreateRole("user").GetAwaiter().GetResult();
                }
                var user = _appUserRepository.GetUserByUserName(registerUserDto.UserName).Result;
                _appUserRepository.AddRoleToUser(user, "user").GetAwaiter().GetResult();
                _responseApi.StatusCode = HttpStatusCode.OK;
                _responseApi.IsSuccess = true;
                return _responseApi;
            } else
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                foreach ( var error in result.Errors)
                {
                    _responseApi.ErrorMessages.Add(error.Description);
                }
                return _responseApi;
            }
        }

        /// <summary>
        /// Autentifica al usuario con un token JWT Bearer.
        /// </summary>
        public ResponseAPI<AppUserLoginResponseDto> Login(AppUserLoginDto loginUserDto)
        {
            var user = _appUserRepository.GetUserByUserName(loginUserDto.UserName).Result;
            bool isValid = _appUserRepository.IsPasswordValid(user, loginUserDto.Password).Result;
            if (user == null || isValid == false)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("El nombre de usuario o clave son incorrectos");
                return _responseApi;
            }
            var roles = _appUserRepository.GetRolesByUser(user).Result;
            var handlerToken = new JwtSecurityTokenHandler();
            var secretKeyEncoded = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(secretKeyEncoded), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = handlerToken.CreateToken(tokenDescriptor);
            AppUserLoginResponseDto loginUserResponseDto = new AppUserLoginResponseDto()
            {
                Token = handlerToken.WriteToken(token),
                User = _mapper.Map<AppUserLoginDataDto>(user)
            };
            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;
            _responseApi.Result = loginUserResponseDto;
            return _responseApi;
        }
    }
}
