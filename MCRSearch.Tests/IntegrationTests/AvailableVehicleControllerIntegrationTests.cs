using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.SharedDtos;
using MCRSearch.Tests.Commons;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Text;

namespace MCRSearch.Tests.IntegrationTests
{
    [TestClass]
    public class AvailableVehicleControllerIntegrationTests : BaseTests
    {
        private static readonly string url = "api/availableVehicle";
        [TestMethod]
        public async Task GetAvailableVehiclesByName_ReturnsOkResult()
        {
            var nameDb = Guid.NewGuid().ToString();
            var factory = BuildWebApplicationFactory(nameDb);
            var client = factory.CreateClient();
            var response = await client.GetAsync($"{url}/Colombia/Bogotá D.C./Bogotá D.C.");

            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<List<AvailableVehicleDto>>(await Task.Run(() => response.Content.ReadAsStringAsync()));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<AvailableVehicleDto>));
            Assert.AreEqual(5, result.Count);
        }
        [TestMethod]
        public async Task GetAvailableVehiclesById_ReturnsOkResult()
        {
            var nameDb = Guid.NewGuid().ToString();
            var factory = BuildWebApplicationFactory(nameDb);
            var client = factory.CreateClient();
            var response = await client.GetAsync($"{url}/1/1/1");

            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<List<AvailableVehicleDto>>(await Task.Run(() => response.Content.ReadAsStringAsync()));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<AvailableVehicleDto>));
            Assert.AreEqual(5, result.Count);
        }
        [TestMethod]
        public async Task GetAvailableVehicleInVehicle_ReturnsOkResult()
        {
            var nameDb = Guid.NewGuid().ToString();
            var factory = BuildWebApplicationFactory(nameDb);
            var client = factory.CreateClient();
            var response = await client.GetAsync($"{url}/vehicle/1");

            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<List<AvailableVehicleDto>>(await Task.Run(() => response.Content.ReadAsStringAsync()));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<AvailableVehicleDto>));
        }
        [TestMethod]
        public async Task GetAvailableVehicleInCity_ReturnsOkResult()
        {
            var nameDb = Guid.NewGuid().ToString();
            var factory = BuildWebApplicationFactory(nameDb);
            var client = factory.CreateClient();
            var response = await client.GetAsync($"{url}/city/1");

            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<List<AvailableVehicleDto>>(await Task.Run(() => response.Content.ReadAsStringAsync()));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<AvailableVehicleDto>));
        }
        [TestMethod]
        public async Task CreateAvailableVehicle_ReturnsBadRequest()
        {
            var nameDb = Guid.NewGuid().ToString();
            var factory = BuildWebApplicationFactory(nameDb);
            var client = factory.CreateClient();
            var availableVehicle = await AvailableVehicleControllerCommon.GenerateAvailableVehicle(nameDb);
            var availableVehicleDto = new AvailableVehiclePostDto()
            {
                VehicleId = 0, // Invalid vehicle ID to cause creation failure
                PickUpCityId = availableVehicle.PickUpCityId,
                ReturnCityId = availableVehicle.ReturnCityId
            };
            var content = new StringContent(JsonConvert.SerializeObject(availableVehicleDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<BadRequest>(await Task.Run(() => response.Content.ReadAsStringAsync()));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequest));
        }
        [TestMethod]
        public async Task PatchAvailableVehicle_ReturnsBadRequest()
        {
            var nameDb = Guid.NewGuid().ToString();
            var factory = BuildWebApplicationFactory(nameDb);
            var client = factory.CreateClient();
            var availableVehicle = await AvailableVehicleControllerCommon.GenerateAvailableVehicle(nameDb);
            var availableVehicleDto = new AvailableVehiclePatchDto()
            {
                VehicleId = 0, // Invalid vehicle ID to cause creation failure
                PickUpCityId = availableVehicle.PickUpCityId,
                ReturnCityId = availableVehicle.ReturnCityId
            };
            var content = new StringContent(JsonConvert.SerializeObject(availableVehicleDto), Encoding.UTF8, "application/json");
            var response = await client.PatchAsync(url, content);

            var result = JsonConvert.DeserializeObject<BadRequest>(await Task.Run(() => response.Content.ReadAsStringAsync()));

            // Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public async Task DeleteAvailableVehicle_ReturnsBadRequest()
        {
            var nameDb = Guid.NewGuid().ToString();
            var factory = BuildWebApplicationFactory(nameDb);
            var client = factory.CreateClient();
            var response = await client.DeleteAsync($"{url}/999");

            var result = JsonConvert.DeserializeObject<NoContent>(await Task.Run(() => response.Content.ReadAsStringAsync()));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NoContent));
        }
    }
}
