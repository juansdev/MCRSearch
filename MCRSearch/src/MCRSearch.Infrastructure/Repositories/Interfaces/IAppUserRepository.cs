using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.SharedDtos;
using Microsoft.AspNetCore.Identity;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces
{
    public interface IAppUserRepository
    {
        Task<AppUser?> GetUser(string userId);
        Task<AppUser?> GetUserByUserName(string userId);
        Task<List<AppUser>> GetUsers();
        Task<bool> IsUniqueUser(string user);
        Task<bool> IsPasswordValid(AppUser user, string password);
        Task<IList<string>> GetRolesByUser(AppUser user);
        Task<IdentityResult> CreateUser(AppUserRegisterDto registerUserDto);
        Task<IdentityResult> CreateRole(string role);
        Task<IdentityResult> AddRoleToUser(AppUser user, string role);
        Task<bool> ExistRole(string role);
    }
}
