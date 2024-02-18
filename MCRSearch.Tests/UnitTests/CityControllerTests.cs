using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCRSearch.src.MCRSearch.Application.Services;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Presentation.Controllers;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using System.Diagnostics.Metrics;
using MCRSearch.src.SharedDtos;
using Microsoft.AspNetCore.Mvc;
using MCRSearch.Tests.Helper;

namespace MCRSearch.Tests.UnitTests
{
    [TestClass]
    public class CityControllerTests : BaseTests
    {
        [TestMethod]
        public async Task GetCities_ReturnsOkResult_WhenCitiesAreAvailable()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var cityController = BuildCityController(nameDb);
            var city = await GenerateCity(nameDb);
            await CreateCityHelper(nameDb, city);

            // Act
            var result = await Task.Run(()=> cityController.GetCities());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(List<CityDto>));
        }

        [TestMethod]
        public async Task GetCityById_ReturnsOkResult_WhenCityExists()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var cityController = BuildCityController(nameDb);
            var city = await GenerateCity(nameDb);
            var createdCity = await CreateCityHelper(nameDb, city);

            // Act
            var result = await Task.Run(()=> cityController.GetCity(createdCity.Id));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(CityDto));
        }

        [TestMethod]
        public async Task GetCityByName_ReturnsOkResult_WhenCityExists()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var cityController = BuildCityController(nameDb);
            var city = await GenerateCity(nameDb);
            var createdCity = await CreateCityHelper(nameDb, city);

            // Act
            var result = await Task.Run(() => cityController.GetCity(createdCity.Name));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(CityDto));
        }

        [TestMethod]
        public async Task CreateCity_ReturnsBadRequestResult_WhenCityCreationFails()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var cityController = BuildCityController(nameDb);
            var city = await GenerateCity(nameDb);
            var cityDto = new CityPostDto()
            {
                Name = "",
                DepartmentId = city.DepartmentId
            };

            // Act
            cityController.ModelState.AddModelError("Name", "Required");
            var result = await Task.Run(() => cityController.CreateCity(cityDto));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task PatchCity_ReturnsBadRequestResult_WhenCityUpdateFails()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var cityController = BuildCityController(nameDb);
            var city = await GenerateCity(nameDb);
            var cityDto = new CityPatchDto()
            {
                Name = "",
                DepartmentId = city.DepartmentId
            };

            // Act
            cityController.ModelState.AddModelError("Name", "Required");
            var result = await Task.Run(() => cityController.PatchCity(cityDto));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task DeleteCity_ReturnsNotFoundResult_WhenCityDoesNotExist()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var cityController = BuildCityController(nameDb);
            var id = 999; // Nonexistent city ID

            // Act
            var result = await Task.Run(() => cityController.DeleteCity(id));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        public static async Task<City> GenerateCity(string nameDb)
        {
            var department = await DepartmentControllerTests.GenerateDepartment(nameDb);
            department = await DepartmentControllerTests.CreateDepartmentHelper(nameDb, department);
            return new City
            {
                Name = UtilHelper.RandomString(6),
                DepartmentId = department.Id
            };
        }

        public static async Task<City> CreateCityHelper(string nameDb, City city)
        {
            var cityRepository = BuildCityRepository(nameDb);
            await cityRepository.CreateCity(city);
            return await cityRepository.GetCity(city.Id);
        }

        private static CityRepository BuildCityRepository(string nameDb)
        {
            var context = BuildContext(nameDb);
            return new CityRepository(context);
        }

        private static CityService BuildCityService(string nameDb)
        {
            var cityRepository = BuildCityRepository(nameDb);
            var mapper = ConfigAutoMapper();
            return new CityService(cityRepository, mapper);
        }

        private static CityController BuildCityController(string nameDb)
        {
            var httpContext = new DefaultHttpContext();
            var cityService = BuildCityService(nameDb);
            AppUserHelper.MockAuth(httpContext);
            return new CityController(cityService);
        }
    }
}
