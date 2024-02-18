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
    public class VehicleBrandControllerTests : BaseTests
    {
        [TestMethod]
        public async Task GetVehicleBrands_ReturnsOk_WhenVehicleBrandsExist()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleBrand = GenerateVehicleBrand();
            await CreateVehicleBrandHelper(nameDb, vehicleBrand);

            var vehicleBrandController = BuildVehicleBrandController(nameDb);
            var result = await Task.Run(()=> vehicleBrandController.GetVehicleBrands());

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetVehicleBrandById_ReturnsOk_WhenVehicleBrandExists()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleBrand = GenerateVehicleBrand();
            await CreateVehicleBrandHelper(nameDb, vehicleBrand);

            var vehicleBrandController = BuildVehicleBrandController(nameDb);
            var result = await Task.Run(() => vehicleBrandController.GetVehicleBrand(vehicleBrand.Id));

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetVehicleBrandByName_ReturnsOk_WhenVehicleBrandExists()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleBrand = GenerateVehicleBrand();
            await CreateVehicleBrandHelper(nameDb, vehicleBrand);

            var vehicleBrandController = BuildVehicleBrandController(nameDb);
            var result = await Task.Run(()=> vehicleBrandController.GetVehicleBrand(vehicleBrand.Name));

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateVehicleBrand_ReturnsCreated_WhenVehicleBrandIsCreated()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleBrandDto = new VehicleBrandPostDto { Name = UtilHelper.RandomString(6) };

            var vehicleBrandController = BuildVehicleBrandController(nameDb);
            var result = await Task.Run(() => vehicleBrandController.CreateVehicleBrand(vehicleBrandDto));

            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteResult));
        }

        [TestMethod]
        public async Task PatchVehicleBrand_ReturnsNoContent_WhenVehicleBrandIsUpdated()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleBrand = GenerateVehicleBrand();
            await CreateVehicleBrandHelper(nameDb, vehicleBrand);

            var vehicleBrandDto = new VehicleBrandPatchDto { Id = vehicleBrand.Id, Name = UtilHelper.RandomString(6) };

            var vehicleBrandController = BuildVehicleBrandController(nameDb);
            var result = await Task.Run(() => vehicleBrandController.PatchVehicleBrand(vehicleBrandDto));

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteVehicleBrand_ReturnsNoContent_WhenVehicleBrandIsDeleted()
        {
            var nameDb = UtilHelper.RandomString(10);
            var vehicleBrand = GenerateVehicleBrand();
            await CreateVehicleBrandHelper(nameDb, vehicleBrand);

            var vehicleBrandController = BuildVehicleBrandController(nameDb);
            var result = await Task.Run(() => vehicleBrandController.DeleteVehicleBrand(vehicleBrand.Id));

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        public static VehicleBrand GenerateVehicleBrand()
        {
            return new VehicleBrand
            {
                Name = UtilHelper.RandomString(6)
            };
        }

        public static async Task<VehicleBrand> CreateVehicleBrandHelper(string nameDb, VehicleBrand vehicleBrand)
        {
            var vehicleBrandRepository = BuildVehicleBrandRepository(nameDb);
            await vehicleBrandRepository.CreateVehicleBrand(vehicleBrand);
            return await vehicleBrandRepository.GetVehicleBrand(vehicleBrand.Id);
        }

        private static VehicleBrandRepository BuildVehicleBrandRepository(string nameDb)
        {
            var context = BuildContext(nameDb);
            return new VehicleBrandRepository(context);
        }

        private static VehicleBrandService BuildVehicleBrandService(string nameDb)
        {
            var vehicleBrandRepository = BuildVehicleBrandRepository(nameDb);
            var mapper = ConfigAutoMapper();
            return new VehicleBrandService(vehicleBrandRepository, mapper);
        }

        private static VehicleBrandController BuildVehicleBrandController(string nameDb)
        {
            var httpContext = new DefaultHttpContext();
            var vehicleBrandService = BuildVehicleBrandService(nameDb);
            AppUserHelper.MockAuth(httpContext);
            return new VehicleBrandController(vehicleBrandService);
        }
    }
}
