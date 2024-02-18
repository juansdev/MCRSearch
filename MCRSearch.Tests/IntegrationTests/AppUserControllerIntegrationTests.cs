using MCRSearch.src.SharedDtos;
using MCRSearch.Tests.Commons;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Text;

namespace MCRSearch.Tests.IntegrationTests
{
    [TestClass]
    public class AppUserControllerIntegrationTests : BaseTests
    {
        private static readonly string url = "api/users";
        [TestMethod]
        public async Task GetUsers_ReturnsOkResult()
        {
            var nameDb = Guid.NewGuid().ToString();
            var factory = BuildWebApplicationFactory(nameDb);
            var client = factory.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<List<AppUserDto>>(await Task.Run(() => response.Content.ReadAsStringAsync()));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<AppUserDto>));
        }
        [TestMethod]
        public async Task GetUser_ReturnsOkResult()
        {
            var nameDb = Guid.NewGuid().ToString();
            var factory = BuildWebApplicationFactory(nameDb);
            var client = factory.CreateClient();
            var response = await client.GetAsync($"{url}/02174cf0–9412–4cfe-afbf-59f706d72cf6");

            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<AppUserDto>(await Task.Run(() => response.Content.ReadAsStringAsync()));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AppUserDto));
        }
        [TestMethod]
        public async Task GetUser_ReturnsNotFound()
        {
            var nameDb = Guid.NewGuid().ToString();
            var factory = BuildWebApplicationFactory(nameDb);
            var client = factory.CreateClient();
            var response = await client.GetAsync($"{url}/02174ff0–9412–4cfe-afbf-59f706d72cf6");

            var result = JsonConvert.DeserializeObject<NotFoundResult>(await Task.Run(() => response.Content.ReadAsStringAsync()));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public async Task Register_ReturnsBadRequest()
        {
            var nameDb = Guid.NewGuid().ToString();
            var factory = BuildWebApplicationFactory(nameDb);
            var client = factory.CreateClient();
            var appUserController = AppUserControllerCommon.BuildAppUserController(nameDb);
            var appUserRegisterDto = AppUserControllerCommon.GenerateAppUserRegister();
            appUserRegisterDto.Password = ""; // Invalid password to cause registration failure
            var content = new StringContent(JsonConvert.SerializeObject(appUserRegisterDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{url}/register", content);

            var result = JsonConvert.DeserializeObject<BadRequest>(await Task.Run(() => response.Content.ReadAsStringAsync()));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequest));
        }
        [TestMethod]
        public async Task Register_ReturnsOkResult()
        {
            var nameDb = Guid.NewGuid().ToString();
            var factory = BuildWebApplicationFactory(nameDb);
            var client = factory.CreateClient();
            var appUserController = AppUserControllerCommon.BuildAppUserController(nameDb);
            var appUserRegisterDto = AppUserControllerCommon.GenerateAppUserRegister();
            var content = new StringContent(JsonConvert.SerializeObject(appUserRegisterDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{url}/register", content);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<ResponseAPI<AppUserLoginResponseDto>>(await Task.Run(() => response.Content.ReadAsStringAsync()));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ResponseAPI<AppUserLoginResponseDto>));
            Assert.IsTrue(result.IsSuccess);
        }
        [TestMethod]
        public async Task Login_ReturnsBadRequest()
        {
            var nameDb = Guid.NewGuid().ToString();
            var factory = BuildWebApplicationFactory(nameDb);
            var client = factory.CreateClient();
            var appUserController = AppUserControllerCommon.BuildAppUserController(nameDb);
            var appUserLoginDto = AppUserControllerCommon.GenerateAppUserLogin();
            appUserLoginDto.Password = ""; // Invalid password to cause registration failure
            var content = new StringContent(JsonConvert.SerializeObject(appUserLoginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{url}/login", content);

            var result = JsonConvert.DeserializeObject<BadRequest>(await Task.Run(() => response.Content.ReadAsStringAsync()));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequest));
        }
    }
}
