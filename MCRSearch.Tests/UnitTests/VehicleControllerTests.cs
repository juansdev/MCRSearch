using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCRSearch.src.MCRSearch.Application.Services;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Presentation.Controllers;
using MCRSearch.src.SharedDtos;
using Microsoft.AspNetCore.Mvc;
using MCRSearch.Tests.Helper;

namespace MCRSearch.Tests.UnitTests
{
    [TestClass]
    public class VehicleControllerTests : BaseTests
    {
        [TestMethod]
        public async Task GetVehicles_ReturnsOkResult_WhenVehiclesAreAvailable()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var vehicleController = BuildVehicleController(nameDb);
            var vehicle = await GenerateVehicle(nameDb);
            await CreateVehicleHelper(nameDb, vehicle);

            // Act
            var result = await Task.Run(()=> vehicleController.GetVehicles());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(List<VehicleDto>));
        }

        [TestMethod]
        public async Task GetVehicleById_ReturnsOkResult_WhenVehicleExists()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var vehicleController = BuildVehicleController(nameDb);
            var vehicle = await GenerateVehicle(nameDb);
            var createdVehicle = await CreateVehicleHelper(nameDb, vehicle);

            // Act
            var result = await Task.Run(()=> vehicleController.GetVehicle(createdVehicle.Id));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(VehicleDto));
        }

        [TestMethod]
        public async Task GetVehicleByModelTypeBrand_ReturnsOkResult_WhenVehicleExists()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var vehicleController = BuildVehicleController(nameDb);
            var vehicle = await GenerateVehicle(nameDb);
            var createdVehicle = await CreateVehicleHelper(nameDb, vehicle);

            // Act
            var result = await Task.Run(() => vehicleController.GetVehicle(createdVehicle.VehicleModel.Name, createdVehicle.VehicleType.Name, createdVehicle.VehicleBrand.Name));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(VehicleDto));
        }

        [TestMethod]
        public async Task GetVehicleByModelTypeBrandId_ReturnsOkResult_WhenVehicleExists()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var vehicleController = BuildVehicleController(nameDb);
            var vehicle = await GenerateVehicle(nameDb);
            var createdVehicle = await CreateVehicleHelper(nameDb, vehicle);

            // Act
            var result = await Task.Run(() => vehicleController.GetVehicle(createdVehicle.VehicleModel.Id, createdVehicle.VehicleType.Id, createdVehicle.VehicleBrand.Id));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(VehicleDto));
        }

        [TestMethod]
        public async Task GetVehiclesInModel_ReturnsOkResult_WhenVehiclesAreAvailable()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var vehicleController = BuildVehicleController(nameDb);
            var vehicle = await GenerateVehicle(nameDb);
            var createdVehicle = await CreateVehicleHelper(nameDb, vehicle);

            // Act
            var result = await Task.Run(() => vehicleController.GetVehiclesInModel(createdVehicle.VehicleModel.Id));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(List<VehicleDto>));
        }

        [TestMethod]
        public async Task GetVehiclesInType_ReturnsOkResult_WhenVehiclesAreAvailable()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var vehicleController = BuildVehicleController(nameDb);
            var vehicle = await GenerateVehicle(nameDb);
            var createdVehicle = await CreateVehicleHelper(nameDb, vehicle);

            // Act
            var result = await Task.Run(() => vehicleController.GetVehiclesInType(createdVehicle.VehicleType.Id));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(List<VehicleDto>));
        }

        [TestMethod]
        public async Task GetVehiclesInBrand_ReturnsOkResult_WhenVehiclesAreAvailable()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var vehicleController = BuildVehicleController(nameDb);
            var vehicle = await GenerateVehicle(nameDb);
            var createdVehicle = await CreateVehicleHelper(nameDb, vehicle);

            // Act
            var result = await Task.Run(() => vehicleController.GetVehiclesInBrand(createdVehicle.VehicleBrand.Id));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(List<VehicleDto>));
        }

        public static async Task<Vehicle> GenerateVehicle(string nameDb)
        {
            var vehicleBrand = VehicleBrandControllerTests.GenerateVehicleBrand();
            vehicleBrand = await VehicleBrandControllerTests.CreateVehicleBrandHelper(nameDb, vehicleBrand);
            var vehicleModel = VehicleModelControllerTests.GenerateVehicleModel();
            vehicleModel = await VehicleModelControllerTests.CreateVehicleModelHelper(nameDb, vehicleModel);
            var vehicleType = VehicleTypeControllerTests.GenerateVehicleType();
            vehicleType = await VehicleTypeControllerTests.CreateVehicleTypeHelper(nameDb, vehicleType);
            return new Vehicle
            {
                VehicleBrandId = vehicleBrand.Id,
                VehicleModelId = vehicleModel.Id,
                VehicleTypeId = vehicleType.Id
            };
        }

        public static async Task<Vehicle> CreateVehicleHelper(string nameDb, Vehicle vehicle)
        {
            var vehicleRepository = BuildVehicleRepository(nameDb);
            await vehicleRepository.CreateVehicle(vehicle);
            return await vehicleRepository.GetVehicle(vehicle.Id);
        }

        private static VehicleRepository BuildVehicleRepository(string nameDb)
        {
            var context = BuildContext(nameDb);
            return new VehicleRepository(context);
        }

        private static VehicleService BuildVehicleService(string nameDb)
        {
            var vehicleRepository = BuildVehicleRepository(nameDb);
            var mapper = ConfigAutoMapper();
            return new VehicleService(vehicleRepository, mapper);
        }

        private static VehicleController BuildVehicleController(string nameDb)
        {
            var httpContext = new DefaultHttpContext();
            var vehicleService = BuildVehicleService(nameDb);
            AppUserHelper.MockAuth(httpContext);
            return new VehicleController(vehicleService);
        }
    }
}
