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
    public class VehicleModelControllerTests : BaseTests
    {
        [TestMethod]
        public async Task GetVehicleModels_ReturnsOk_WhenModelsExist()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleModel = GenerateVehicleModel();
            await CreateVehicleModelHelper(nameDb, vehicleModel);

            var vehicleModelController = BuildVehicleBrandController(nameDb);
            var result = await Task.Run(()=> vehicleModelController.GetVehicleModels());

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetVehicleModelById_ReturnsOk_WhenModelExists()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleModel = GenerateVehicleModel();
            await CreateVehicleModelHelper(nameDb, vehicleModel);

            var vehicleModelController = BuildVehicleBrandController(nameDb);
            var result = await Task.Run(() => vehicleModelController.GetVehicleModel(vehicleModel.Id));

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetVehicleModelByName_ReturnsOk_WhenModelExists()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleModel = GenerateVehicleModel();
            await CreateVehicleModelHelper(nameDb, vehicleModel);

            var vehicleModelController = BuildVehicleBrandController(nameDb);
            var result = await Task.Run(()=> vehicleModelController.GetVehicleModel(vehicleModel.Name));

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateVehicleModel_ReturnsCreated_WhenModelIsValid()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleModelDto = new VehicleModelPostDto { Name = UtilHelper.RandomString(6) };

            var vehicleModelController = BuildVehicleBrandController(nameDb);
            var result = await Task.Run(() => vehicleModelController.CreateVehicleModel(vehicleModelDto));

            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteResult));
        }

        [TestMethod]
        public async Task PatchVehicleModel_ReturnsNoContent_WhenModelIsValid()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleModel = GenerateVehicleModel();
            await CreateVehicleModelHelper(nameDb, vehicleModel);

            var vehicleModelDto = new VehicleModelPatchDto { Id = vehicleModel.Id, Name = UtilHelper.RandomString(6) };

            var vehicleModelController = BuildVehicleBrandController(nameDb);
            var result = await Task.Run(() => vehicleModelController.PatchVehicleModel(vehicleModelDto));

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteVehicleModel_ReturnsNoContent_WhenModelExists()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleModel = GenerateVehicleModel();
            await CreateVehicleModelHelper(nameDb, vehicleModel);

            var vehicleModelController = BuildVehicleBrandController(nameDb);
            var result = await Task.Run(() => vehicleModelController.DeleteVehicleModel(vehicleModel.Id));

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        public static VehicleModel GenerateVehicleModel()
        {
            return new VehicleModel
            {
                Name = UtilHelper.RandomString(6)
            };
        }

        public static async Task<VehicleModel> CreateVehicleModelHelper(string nameDb, VehicleModel vehicleModel)
        {
            var vehicleModelRepository = BuildVehicleModelRepository(nameDb);
            await vehicleModelRepository.CreateVehicleModel(vehicleModel);
            return await vehicleModelRepository.GetVehicleModel(vehicleModel.Id);
        }

        private static VehicleModelRepository BuildVehicleModelRepository(string nameDb)
        {
            var context = BuildContext(nameDb);
            return new VehicleModelRepository(context);
        }

        private static VehicleModelService BuildVehicleModelService(string nameDb)
        {
            var vehicleModelRepository = BuildVehicleModelRepository(nameDb);
            var mapper = ConfigAutoMapper();
            return new VehicleModelService(vehicleModelRepository, mapper);
        }

        private static VehicleModelController BuildVehicleBrandController(string nameDb)
        {
            var httpContext = new DefaultHttpContext();
            var vehicleModelService = BuildVehicleModelService(nameDb);
            AppUserHelper.MockAuth(httpContext);
            return new VehicleModelController(vehicleModelService);
        }
    }
}
