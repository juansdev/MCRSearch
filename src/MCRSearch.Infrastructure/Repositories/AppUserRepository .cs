using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using XSystem.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Infrastructure.Dtos;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para gestionar operaciones relacionadas con usuarios en la base de datos.
    /// </summary>
    public class AppUserRepository : IAppUserRepository
    {
        private readonly ApplicationDbContext _context;
        private string? _secretKey;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public AppUserRepository(ApplicationDbContext context, IConfiguration config, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper) {
            _context = context;
            _secretKey = config.GetValue<string>("ApiSettings:Secret");
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene un usuario por su identificador.
        /// </summary>
        public async Task<AppUser?> GetUser(string userId)
        {
            return await _context.AppUser.FirstOrDefaultAsync(u => u.Id == userId);
        }

        /// <summary>
        /// Obtiene la lista de todos los usuarios.
        /// </summary>
        public async Task<List<AppUser>> GetUsers()
        {
            return await _context.AppUser.OrderBy(u => u.UserName).ToListAsync();
        }

        /// <summary>
        /// Verifica si un nombre de usuario es único.
        /// </summary>
        public async Task<bool> IsUniqueUser(string user)
        {
            return await _context.AppUser.FirstOrDefaultAsync(u => u.UserName == user) == null;
        }

        /// <summary>
        /// Realiza el proceso de inicio de sesión y genera un token JWT.
        /// </summary>
        public async Task<LoginUserResponseDto> Login(LoginUserDto loginUserDto)
        {
            // var passwordEncrypt = getMd5(loginUserDto.Password);
            var user = await _context.AppUser.FirstOrDefaultAsync(u => u.UserName.ToLower() == loginUserDto.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginUserDto.Password);
            if (user == null || isValid == false)
            {
                return new LoginUserResponseDto()
                {
                    Token = "",
                    User = null
                };
            }
            var roles = await _userManager.GetRolesAsync(user);
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
            LoginUserResponseDto loginUserResponseDto = new LoginUserResponseDto()
            {
                Token = handlerToken.WriteToken(token),
                User = _mapper.Map<AppUserDataDto>(user)
            };
            return loginUserResponseDto;
        }

        /// <summary>
        /// Encripta la clave aplicando el algoritmo MD5.
        /// </summary>
        public static string getMd5(string password)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(password);
            data = x.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)
            {
                resp += data[i].ToString("x2").ToLower();
            }
            return resp;
        }

        /// <summary>
        /// Registra un nuevo usuario en la base de datos.
        /// </summary>
        public async Task<AppUserDataDto> Register(RegisterUserDto registerUserDto)
        {
            AppUser user = new AppUser()
            {
                UserName = registerUserDto.UserName,
                Email = registerUserDto.UserName,
                NormalizedEmail = registerUserDto.UserName.ToUpper(),
                Name = registerUserDto.Name
            };
            var result = await _userManager.CreateAsync(user, registerUserDto.Password);
            if (result.Succeeded)
            {
                if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole("admin"));
                    await _roleManager.CreateAsync(new IdentityRole("user"));
                }
                await _userManager.AddToRoleAsync(user, "user");
                var userReturned = _context.AppUser.FirstOrDefault(u => u.UserName == registerUserDto.UserName);
                return _mapper.Map<AppUserDataDto>(userReturned);
            }
            return new AppUserDataDto();
        }
    }
}
