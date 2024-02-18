using MCRSearch.src.MCRSearch.Application.Services;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories;
using MCRSearch.src.MCRSearch.Presentation.Controllers;
using MCRSearch.src.SharedDtos;
using MCRSearch.Tests.UnitTests.Helper;
using MCRSearch.Tests.UnitTests;

namespace MCRSearch.Tests.Commons
{
    public class AvailableVehicleControllerCommon: BaseTests
    {
        public static async Task<AvailableVehicle> GenerateAvailableVehicle(string nameDb)
        {
            var vehicle = await VehicleControllerTests.GenerateVehicle(nameDb);
            vehicle = await VehicleControllerTests.CreateVehicleHelper(nameDb, vehicle);
            var city = await CityControllerTests.GenerateCity(nameDb);
            city = await CityControllerTests.CreateCityHelper(nameDb, city);
            return new AvailableVehicle
            {
                VehicleId = vehicle.Id,
                PickUpCityId = city.Id,
                ReturnCityId = city.Id
            };
        }
        public static AvailableVehicleDto GetAvailableVehicleDtoHelper(string nameDb, int availableVehicleId)
        {
            var availableVehicleRepository = BuildAvailableVehicleService(nameDb);
            return availableVehicleRepository.GetAvailableVehicle(availableVehicleId);
        }
        public static async Task<AvailableVehicle> CreateAvailableVehicleHelper(string nameDb, AvailableVehicle availableVehicle)
        {
            var availableVehicleRepository = BuildAvailableVehicleRepository(nameDb);
            await availableVehicleRepository.CreateAvailableVehicle(availableVehicle);
            return await availableVehicleRepository.GetAvailableVehicle(availableVehicle.Id);
        }

        public static AvailableVehicleRepository BuildAvailableVehicleRepository(string nameDb)
        {
            var context = BuildContext(nameDb);
            return new AvailableVehicleRepository(context);
        }

        public static AvailableVehicleService BuildAvailableVehicleService(string nameDb)
        {
            var availableVehicleRepository = BuildAvailableVehicleRepository(nameDb);
            var mapper = ConfigAutoMapper();
            return new AvailableVehicleService(availableVehicleRepository, mapper);
        }

        public static AvailableVehicleController BuildAvailableVehicleController(string nameDb)
        {
            var httpContext = new DefaultHttpContext();
            var avaiableVehicleService = BuildAvailableVehicleService(nameDb);
            AppUserHelper.MockAuth(httpContext);
            return new AvailableVehicleController(avaiableVehicleService);
        }
    }
}
