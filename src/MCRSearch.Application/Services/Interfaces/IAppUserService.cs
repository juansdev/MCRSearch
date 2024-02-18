using MCRSearch.src.SharedDtos;

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
