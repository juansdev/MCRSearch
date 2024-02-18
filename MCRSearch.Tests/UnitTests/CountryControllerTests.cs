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
    public class CountryControllerTests : BaseTests
    {
        [TestMethod]
        public async Task GetCountries_ReturnsOk_WhenCountriesExist()
        {
            var nameDb = UtilHelper.RandomString(10);
            var country = GenerateCountry();
            await CreateCountryHelper(nameDb, country);

            var controller = BuildCountryController(nameDb);
            var result = await Task.Run(()=> controller.GetCountries());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetCountryById_ReturnsOk_WhenCountryExists()
        {
            var nameDb = UtilHelper.RandomString(10);
            var country = GenerateCountry();
            await CreateCountryHelper(nameDb, country);

            var controller = BuildCountryController(nameDb);
            var result = await Task.Run(()=> controller.GetCountry(country.Id));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetCountryByName_ReturnsOk_WhenCountryExists()
        {
            var nameDb = UtilHelper.RandomString(10);
            var country = GenerateCountry();
            await CreateCountryHelper(nameDb, country);

            var controller = BuildCountryController(nameDb);
            var result = await Task.Run(() => controller.GetCountry(country.Name));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateVehicleModel_ReturnsCreated_WhenModelIsValid()
        {
            var nameDb = UtilHelper.RandomString(10);
            var countryDto = new CountryPostDto { Name = UtilHelper.RandomString(6) };

            var controller = BuildCountryController(nameDb);
            var result = await Task.Run(() => controller.CreateVehicleModel(countryDto));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteResult));
        }

        [TestMethod]
        public async Task PatchVehicleModel_ReturnsNoContent_WhenModelIsValid()
        {
            var nameDb = UtilHelper.RandomString(10);
            var country = GenerateCountry();
            await CreateCountryHelper(nameDb, country);

            var countryDto = new CountryPatchDto { Id = country.Id, Name = UtilHelper.RandomString(6) };

            var controller = BuildCountryController(nameDb);
            var result = await Task.Run(() => controller.PatchVehicleModel(countryDto));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteVehicleModel_ReturnsNoContent_WhenCountryExists()
        {
            var nameDb = UtilHelper.RandomString(10);
            var country = GenerateCountry();
            await CreateCountryHelper(nameDb, country);

            var controller = BuildCountryController(nameDb);
            var result = await Task.Run(() => controller.DeleteVehicleModel(country.Id));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
        public static Country GenerateCountry()
        {
            return new Country
            {
                Name = UtilHelper.RandomString(6)
            };
        }

        public static async Task<Country> CreateCountryHelper(string nameDb, Country country)
        {
            var countryRepository = BuildCountryRepository(nameDb);
            await countryRepository.CreateCountry(country);
            return await countryRepository.GetCountry(country.Id);
        }

        private static CountryRepository BuildCountryRepository(string nameDb)
        {
            var context = BuildContext(nameDb);
            return new CountryRepository(context);
        }

        private static CountryService BuildCountryService(string nameDb)
        {
            var countryRepository = BuildCountryRepository(nameDb);
            var mapper = ConfigAutoMapper();
            return new CountryService(countryRepository, mapper);
        }

        private static CountryController BuildCountryController(string nameDb)
        {
            var httpContext = new DefaultHttpContext();
            var countryService = BuildCountryService(nameDb);
            AppUserHelper.MockAuth(httpContext);
            return new CountryController(countryService);
        }
    }
}
