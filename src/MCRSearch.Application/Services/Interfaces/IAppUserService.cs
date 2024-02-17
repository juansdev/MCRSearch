using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface IAppUserService
    {
        List<AppUserDto> GetUsers();
        AppUserDto GetUser(string userId);
        ResponseAPI<LoginUserResponseDto> Register(RegisterUserDto registerUserDto);
        ResponseAPI<LoginUserResponseDto> Login(LoginUserDto loginUserDto);
    }
}
