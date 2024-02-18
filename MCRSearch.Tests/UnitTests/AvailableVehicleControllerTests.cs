using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCRSearch.src.MCRSearch.Application.Services;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.Tests.UnitTests.Helper;
using MCRSearch.src.SharedDtos;
using MCRSearch.src.MCRSearch.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using MCRSearch.Tests.Commons;

namespace MCRSearch.Tests.UnitTests
{
    [TestClass]
    public class AvailableVehicleControllerTests : BaseTests
    {
        [TestMethod]
        public async Task GetAvailableVehicles_ReturnsOkResult_WhenVehiclesAreAvailable()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var availableVehicleController = AvailableVehicleControllerCommon.BuildAvailableVehicleController(nameDb);
            var availableVehicle = await AvailableVehicleControllerCommon.GenerateAvailableVehicle(nameDb);
            availableVehicle = await AvailableVehicleControllerCommon.CreateAvailableVehicleHelper(nameDb, availableVehicle);
            var availableVehicleDto = AvailableVehicleControllerCommon.GetAvailableVehicleDtoHelper(nameDb, availableVehicle.Id);

            // Act
            var result = await Task.Run(()=> availableVehicleController.GetAvailableVehicles(availableVehicleDto.PickUpCity.Department.Country.Name, availableVehicleDto.PickUpCity.Name, availableVehicleDto.ReturnCity.Name));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(List<AvailableVehicleDto>));
        }

        [TestMethod]
        public async Task GetAvailableVehicle_ReturnsOkResult_WhenVehicleExists()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var availableVehicleController = AvailableVehicleControllerCommon.BuildAvailableVehicleController(nameDb);
            var availableVehicle = await AvailableVehicleControllerCommon.GenerateAvailableVehicle(nameDb);
            var createdAvailableVehicle = await AvailableVehicleControllerCommon.CreateAvailableVehicleHelper(nameDb, availableVehicle);

            // Act
            var result = await Task.Run(()=> availableVehicleController.GetAvailableVehicle(createdAvailableVehicle.Id));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(AvailableVehicleDto));
        }

        [TestMethod]
        public async Task GetAvailableVehiclesInVehicle_ReturnsOkResult_WhenVehiclesAreAvailable()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var availableVehicleController = AvailableVehicleControllerCommon.BuildAvailableVehicleController(nameDb);
            var availableVehicle = await AvailableVehicleControllerCommon.GenerateAvailableVehicle(nameDb);
            var createdAvailableVehicle = await AvailableVehicleControllerCommon.CreateAvailableVehicleHelper(nameDb, availableVehicle);

            // Act
            var result = await Task.Run(()=> availableVehicleController.GetAvailableVehiclesInVehicle(createdAvailableVehicle.VehicleId));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(List<AvailableVehicleDto>));
        }

        [TestMethod]
        public async Task GetAvailableVehiclesInCity_ReturnsOkResult_WhenVehiclesAreAvailable()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var availableVehicleController = AvailableVehicleControllerCommon.BuildAvailableVehicleController(nameDb);
            var availableVehicle = await AvailableVehicleControllerCommon.GenerateAvailableVehicle(nameDb);
            var createdAvailableVehicle = await AvailableVehicleControllerCommon.CreateAvailableVehicleHelper(nameDb, availableVehicle);

            // Act
            var result = await Task.Run(() => availableVehicleController.GetAvailableVehiclesInCity(createdAvailableVehicle.PickUpCityId));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(List<AvailableVehicleDto>));
        }

        [TestMethod]
        public async Task CreateAvailableVehicle_ReturnsBadRequestResult_WhenVehicleCreationFails()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var availableVehicleController = AvailableVehicleControllerCommon.BuildAvailableVehicleController(nameDb);
            var availableVehicle = await AvailableVehicleControllerCommon.GenerateAvailableVehicle(nameDb);
            availableVehicle = await AvailableVehicleControllerCommon.CreateAvailableVehicleHelper(nameDb, availableVehicle);
            var availableVehicleDto = new AvailableVehiclePostDto()
            {
                VehicleId = 0, // Invalid vehicle ID to cause creation failure
                PickUpCityId = availableVehicle.PickUpCityId,
                ReturnCityId = availableVehicle.ReturnCityId
            };

            // Act
            availableVehicleController.ModelState.AddModelError("VehicleId", "Required");
            var result = await Task.Run(()=> availableVehicleController.CreateAvailableVehicle(availableVehicleDto));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task PatchAvailableVehicle_ReturnsBadRequestResult_WhenVehicleUpdateFails()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var availableVehicleController = AvailableVehicleControllerCommon.BuildAvailableVehicleController(nameDb);
            var availableVehicle = await AvailableVehicleControllerCommon.GenerateAvailableVehicle(nameDb);
            availableVehicle = await AvailableVehicleControllerCommon.CreateAvailableVehicleHelper(nameDb, availableVehicle);
            var availableVehicleDto = new AvailableVehiclePatchDto()
            {
                VehicleId = 0, // Invalid vehicle ID to cause creation failure
                PickUpCityId = availableVehicle.PickUpCityId,
                ReturnCityId = availableVehicle.ReturnCityId
            };

            // Act
            availableVehicleController.ModelState.AddModelError("VehicleId", "Required");
            var result = await Task.Run(()=> availableVehicleController.PatchVehicleModel(availableVehicleDto));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task DeleteAvailableVehicle_ReturnsNotFoundResult_WhenVehicleDoesNotExist()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var availableVehicleController = AvailableVehicleControllerCommon.BuildAvailableVehicleController(nameDb);
            var id = 999; // Nonexistent vehicle ID

            // Act
            var result = await Task.Run(()=> availableVehicleController.DeleteVehicleModel(id));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
