using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.Tests.UnitTests.Helper;
using MCRSearch.src.SharedDtos;
using Microsoft.AspNetCore.Mvc;
using MCRSearch.Tests.Commons;

namespace MCRSearch.Tests.UnitTests
{
    [TestClass]
    public class AppUserControllerTests : BaseTests
    {
        [TestMethod]
        public async Task GetUsers_ReturnsOkResult_WhenAdminRoleIsAuthorized()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var appUserController = AppUserControllerCommon.BuildAppUserController(nameDb);

            // Act
            var result = await Task.Run(()=> appUserController.GetUsers());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(List<AppUserDto>));
        }

        [TestMethod]
        public async Task GetUser_ReturnsOkResult_WhenAdminRoleIsAuthorizedAndUserExists()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var appUserController = AppUserControllerCommon.BuildAppUserController(nameDb);
            var appUserRegisterDto = AppUserControllerCommon.GenerateAppUserRegister();
            AppUserControllerCommon.CreateAppUserHelper(nameDb, appUserRegisterDto).Wait();
            var appUserRepository = AppUserControllerCommon.BuildAppUserRepository(nameDb);
            var userName = appUserRegisterDto.UserName;

            // Act
            var user = await appUserRepository.GetUserByUserName(userName);
            var result = await Task.Run(() => appUserController.GetUser(user.Id));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(AppUserDto));
        }

        [TestMethod]
        public async Task GetUser_ReturnsNotFoundResult_WhenAdminRoleIsAuthorizedAndUserDoesNotExist()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var appUserController = AppUserControllerCommon.BuildAppUserController(nameDb);
            var id = "nonexistentId";

            // Act
            var result = await Task.Run(()=> appUserController.GetUser(id));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Register_ReturnsBadRequestResult_WhenUserRegistrationFails()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var appUserController = AppUserControllerCommon.BuildAppUserController(nameDb);
            var appUserRegisterDto = AppUserControllerCommon.GenerateAppUserRegister();
            appUserRegisterDto.Password = ""; // Invalid password to cause registration failure

            // Act
            var result = await Task.Run(()=> appUserController.Register(appUserRegisterDto));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsInstanceOfType(badRequestResult.Value, typeof(ResponseAPI<AppUserLoginResponseDto>));
            var responseApi = badRequestResult.Value as ResponseAPI<AppUserLoginResponseDto>;
            Assert.IsFalse(responseApi.IsSuccess);
        }
        [TestMethod]
        public async Task Register_ReturnsOkResult_WhenUserIsSuccessfullyRegistered()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var appUserController = AppUserControllerCommon.BuildAppUserController(nameDb);
            var appUserRegisterDto = AppUserControllerCommon.GenerateAppUserRegister();

            // Act
            var result = await Task.Run(()=> appUserController.Register(appUserRegisterDto));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(ResponseAPI<AppUserLoginResponseDto>));
            var responseApi = okResult.Value as ResponseAPI<AppUserLoginResponseDto>;
            Assert.IsTrue(responseApi.IsSuccess);
        }

        [TestMethod]
        public async Task Login_ReturnsBadRequestResult_WhenUserLoginFails()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var appUserController = AppUserControllerCommon.BuildAppUserController(nameDb);
            var appUserLoginDto = AppUserControllerCommon.GenerateAppUserLogin();
            appUserLoginDto.Password = ""; // Invalid password to cause login failure

            // Act
            var result = await Task.Run(()=> appUserController.Login(appUserLoginDto));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsInstanceOfType(badRequestResult.Value, typeof(ResponseAPI<AppUserLoginResponseDto>));
            var responseApi = badRequestResult.Value as ResponseAPI<AppUserLoginResponseDto>;
            Assert.IsFalse(responseApi.IsSuccess);
        }

        [TestMethod]
        public async Task Login_ReturnsOkResult_WhenUserLoginIsSuccessful()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var appUserController = AppUserControllerCommon.BuildAppUserController(nameDb);
            var appUserRegisterDto = AppUserControllerCommon.GenerateAppUserRegister();
            await AppUserControllerCommon.CreateAppUserHelper(nameDb, appUserRegisterDto);
            await AppUserControllerCommon.AddRoleToUser(nameDb, appUserRegisterDto.UserName, "user");
            var appUserLoginDto = new AppUserLoginDto
            {
                UserName = appUserRegisterDto.UserName,
                Password = appUserRegisterDto.Password
            };

            // Act
            var result = await Task.Run(()=> appUserController.Login(appUserLoginDto));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(ResponseAPI<AppUserLoginResponseDto>));
            var responseApi = okResult.Value as ResponseAPI<AppUserLoginResponseDto>;
            Assert.IsTrue(responseApi.IsSuccess);
        }
    }
}
