using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Dtos;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces
{
    public interface IAppUserRepository
    {
        Task<List<AppUser>> GetUsers();
        Task<AppUser?> GetUser(string userId);
        Task<bool> IsUniqueUser(string user);
        Task<LoginUserResponseDto> Login(LoginUserDto loginUserDto);
        Task<AppUserDataDto> Register(RegisterUserDto registerUserDto);
    }
}
