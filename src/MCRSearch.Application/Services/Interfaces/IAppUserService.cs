using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Infrastructure.Dtos;
using MCRSearch.src.MCRSearch.Presentation.DTOs;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface IAppUserService
    {
        List<AppUserDto> GetUsers();
        AppUserDto GetUser(string userId);
        ResponseAPI<AppUserLoginResponseDto> Register(AppUserRegisterDto registerUserDto);
        ResponseAPI<AppUserLoginResponseDto> Login(AppUserLoginDto loginUserDto);
    }
}
