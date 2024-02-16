using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class AppUserService: IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;
        protected ResponseAPI _responseApi;

        public AppUserService(IAppUserRepository appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
            _responseApi = new ResponseAPI();
        }

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

        public AppUserDto GetUser(string userId)
        {
            var itemUser = _appUserRepository.GetUser(userId).Result;
            return _mapper.Map<AppUserDto>(itemUser);
        }

        public ResponseAPI Register(RegisterUserDto registerUserDto)
        {
            bool validateUserNameUnique = _appUserRepository.IsUniqueUser(registerUserDto.UserName).Result;
            if (!validateUserNameUnique)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("El nombre de usuario ya existe");
                return _responseApi;
            }
            var user = _appUserRepository.Register(registerUserDto).Result;
            if (user == null)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("Error en el registro");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }

        public ResponseAPI Login(LoginUserDto loginUserDto)
        {
            var responseLogin = _appUserRepository.Login(loginUserDto).Result;
            if (responseLogin.User == null || string.IsNullOrEmpty(responseLogin.Token))
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("El nombre de usuario o clave son incorrectos");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;
            _responseApi.Result = responseLogin;
            return _responseApi;
        }
    }
}
