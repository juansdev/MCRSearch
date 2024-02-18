using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MCRSearch.src.SharedDtos;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para gestionar operaciones relacionadas con usuarios en la base de datos.
    /// </summary>
    public class AppUserRepository : IAppUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AppUserRepository(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        public async Task<AppUser?> GetUser(string userId)
        {
            return await _context.AppUser.FirstOrDefaultAsync(u => u.Id == userId);
        }

        /// <summary>
        /// Obtiene un usuario por su nombre.
        /// </summary>
        public async Task<AppUser?> GetUserByUserName(string userName)
        {
            return await _context.AppUser.FirstOrDefaultAsync(u => u.UserName.ToLower() == userName.ToLower());
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
        /// Verifica si la clave del usuario es valido.
        /// </summary>
        public async Task<bool> IsPasswordValid(AppUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        /// <summary>
        /// Verifica si el rol existe.
        /// </summary>
        public async Task<bool> ExistRole(string role)
        {
            return await _roleManager.RoleExistsAsync(role);
        }

        /// <summary>
        /// Obtiene los roles del usuario.
        /// </summary>
        public async Task<IList<string>> GetRolesByUser(AppUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        /// <summary>
        /// Crea el usuario.
        /// </summary>
        public async Task<IdentityResult> CreateUser(AppUserRegisterDto registerUserDto)
        {
            AppUser user = new AppUser()
            {
                UserName = registerUserDto.UserName,
                Email = registerUserDto.UserName,
                NormalizedEmail = registerUserDto.UserName.ToUpper(),
                Name = registerUserDto.Name
            };
            return await _userManager.CreateAsync(user, registerUserDto.Password);
        }

        /// <summary>
        /// Crea un rol.
        /// </summary>
        public async Task<IdentityResult> CreateRole(string role)
        {
            return await _roleManager.CreateAsync(new IdentityRole(role));
        }

        /// <summary>
        /// Agrega un rol al usuario.
        /// </summary>
        public async Task<IdentityResult> AddRoleToUser(AppUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }
    }
}
