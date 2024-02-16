using MCRSearch.src.MCRSearch.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface IAppUserService
    {
        public List<AppUserDto> GetUsers();
        public AppUserDto GetUser(string userId);
        public ResponseAPI Register(RegisterUserDto registerUserDto);
        public ResponseAPI Login(LoginUserDto loginUserDto);
    }
}
