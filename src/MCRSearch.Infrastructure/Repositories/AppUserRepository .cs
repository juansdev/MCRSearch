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

        public async Task<AppUser?> GetUser(string userId)
        {
            return await _context.AppUser.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<List<AppUser>> GetUsers()
        {
            return await _context.AppUser.OrderBy(u => u.UserName).ToListAsync();
        }

        public async Task<bool> IsUniqueUser(string user)
        {
            return await _context.AppUser.FirstOrDefaultAsync(u => u.UserName == user) == null;
        }

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
                    await _roleManager.CreateAsync(new IdentityRole("registered"));
                    await _userManager.AddToRoleAsync(user, "admin");
                } else
                {
                    await _userManager.AddToRoleAsync(user, "registered");
                }
                var userReturned = _context.AppUser.FirstOrDefault(u => u.UserName == registerUserDto.UserName);
                return _mapper.Map<AppUserDataDto>(userReturned);
            }
            return new AppUserDataDto();
        }
    }
}
