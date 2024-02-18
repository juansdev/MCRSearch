using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCRSearch.src.MCRSearch.Application.Services;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.Tests.UnitTests.Helper;
using MCRSearch.src.SharedDtos;
using MCRSearch.src.MCRSearch.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MCRSearch.Tests.UnitTests
{
    [TestClass]
    public class VehicleTypeControllerTests : BaseTests
    {
        [TestMethod]
        public async Task GetVehicleTypes_ReturnsOk_WhenVehicleTypesExist()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleType = GenerateVehicleType();
            await CreateVehicleTypeHelper(nameDb, vehicleType);

            var vehicleTypeController = BuildVehicleTypeController(nameDb);
            var result = await Task.Run(() => vehicleTypeController.GetVehicleTypes());

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetVehicleTypeById_ReturnsOk_WhenVehicleTypeExists()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleType = GenerateVehicleType();
            await CreateVehicleTypeHelper(nameDb, vehicleType);

            var vehicleTypeController = BuildVehicleTypeController(nameDb);
            var result = await Task.Run(()=> vehicleTypeController.GetVehicleType(vehicleType.Id));

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetVehicleTypeByName_ReturnsOk_WhenVehicleTypeExists()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleType = GenerateVehicleType();
            await CreateVehicleTypeHelper(nameDb, vehicleType);

            var vehicleTypeController = BuildVehicleTypeController(nameDb);
            var result = await Task.Run(() => vehicleTypeController.GetVehicleType(vehicleType.Name));

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateVehicleType_ReturnsCreated_WhenVehicleTypeIsValid()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleTypeController = BuildVehicleTypeController(nameDb);
            var vehicleTypeDto = new VehicleTypePostDto { Name = UtilHelper.RandomString(6) };

            var result = await Task.Run(() => vehicleTypeController.CreateVehicleType(vehicleTypeDto));

            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteResult));
        }

        [TestMethod]
        public async Task PatchVehicleType_ReturnsNoContent_WhenVehicleTypeIsValid()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleType = GenerateVehicleType();
            await CreateVehicleTypeHelper(nameDb, vehicleType);

            var vehicleTypeController = BuildVehicleTypeController(nameDb);
            var vehicleTypeDto = new VehicleTypePatchDto { Id = vehicleType.Id, Name = UtilHelper.RandomString(6) };

            var result = await Task.Run(()=> vehicleTypeController.PatchVehicleType(vehicleTypeDto));

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteVehicleType_ReturnsNoContent_WhenVehicleTypeExists()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleType = GenerateVehicleType();
            await CreateVehicleTypeHelper(nameDb, vehicleType);

            var vehicleTypeController = BuildVehicleTypeController(nameDb);
            var result = await Task.Run(()=> vehicleTypeController.DeleteVehicleType(vehicleType.Id));

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
        public static VehicleType GenerateVehicleType()
        {
            return new VehicleType
            {
                Name = UtilHelper.RandomString(6)
            };
        }

        public static async Task<VehicleType> CreateVehicleTypeHelper(string nameDb, VehicleType vehicleType)
        {
            var vehicleTypeRepository = BuildVehicleTypeRepository(nameDb);
            await vehicleTypeRepository.CreateVehicleType(vehicleType);
            return await vehicleTypeRepository.GetVehicleType(vehicleType.Id);
        }

        private static VehicleTypeRepository BuildVehicleTypeRepository(string nameDb)
        {
            var context = BuildContext(nameDb);
            return new VehicleTypeRepository(context);
        }

        private static VehicleTypeService BuildVehicleTypeService(string nameDb)
        {
            var vehicleTypeRepository = BuildVehicleTypeRepository(nameDb);
            var mapper = ConfigAutoMapper();
            return new VehicleTypeService(vehicleTypeRepository, mapper);
        }

        private static VehicleTypeController BuildVehicleTypeController(string nameDb)
        {
            var httpContext = new DefaultHttpContext();
            var vehicleTypeService = BuildVehicleTypeService(nameDb);
            AppUserHelper.MockAuth(httpContext);
            return new VehicleTypeController(vehicleTypeService);
        }
    }
}
