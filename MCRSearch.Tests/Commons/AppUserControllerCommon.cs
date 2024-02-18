using ApiMovies.Controllers;
using MCRSearch.src.MCRSearch.Application.Services;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories;
using MCRSearch.Tests.UnitTests.Helper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MCRSearch.src.SharedDtos;

namespace MCRSearch.Tests.Commons
{
    public class AppUserControllerCommon: BaseTests
    {
        public static async Task<AppUser> CreateAppUserHelper(string nameDb, AppUserRegisterDto appUserRegisterDto)
        {
            var appUserRepository = AppUserControllerCommon.BuildAppUserRepository(nameDb);
            await appUserRepository.CreateUser(appUserRegisterDto);
            return await appUserRepository.GetUserByUserName(appUserRegisterDto.Name);
        }
        public static async Task AddRoleToUser(string nameDb, string userName, string role)
        {
            var appUserRepository = AppUserControllerCommon.BuildAppUserRepository(nameDb);
            var user = await appUserRepository.GetUserByUserName(userName);
            await appUserRepository.AddRoleToUser(user, role);
        }
        public static AppUserRepository BuildAppUserRepository(string nameDb)
        {
            var context = BuildContext(nameDb);
            var myUserStore = new UserStore<AppUser>(context);
            var myRolStore = new RoleStore<IdentityRole>(context);
            var userManager = AppUserHelper.BuildUserManager(myUserStore);
            var roleManager = AppUserHelper.BuildRoleManager(myRolStore);
            return new AppUserRepository(context, userManager, roleManager);
        }

        public static AppUserService BuildAppUserService(string nameDb)
        {
            var userRepository = BuildAppUserRepository(nameDb);
            var mapper = ConfigAutoMapper();
            var myConfiguration = new Dictionary<string, string>
            {
                {
                    "ApiSettings:Secret",
                    "DMAWEIODFAWNEIOGNQWIOJH39H4123894H32FHQW3283910R4H312908RH12RFNH19FN10FN12J39041U3412903J109IR1M"
                }
            };
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(myConfiguration).Build();
            return new AppUserService(userRepository, configuration, mapper);
        }

        public static AppUserController BuildAppUserController(string nameDb)
        {
            var httpContext = new DefaultHttpContext();
            var userService = BuildAppUserService(nameDb);
            AppUserHelper.MockAuth(httpContext);
            return new AppUserController(userService);
        }
        public static AppUserLoginDto GenerateAppUserLogin()
        {
            return new AppUserLoginDto
            {
                UserName = UtilHelper.RandomString(6),
                Password = "Testing1234*"
            };
        }

        public static AppUserRegisterDto GenerateAppUserRegister()
        {
            return new AppUserRegisterDto
            {
                UserName = UtilHelper.RandomString(6),
                Name = UtilHelper.RandomString(6),
                Password = "Testing1234*"
            };
        }
    }
}
