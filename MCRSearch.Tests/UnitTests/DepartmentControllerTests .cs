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
    public class DepartmentControllerTests : BaseTests
    {
        [TestMethod]
        public async Task GetDepartments_ReturnsOkResult_WhenDepartmentsAreAvailable()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var departmentController = BuildDepartmentController(nameDb);

            // Act
            var result = await Task.Run(() => departmentController.GetDepartments());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(List<DepartmentDto>));
        }

        [TestMethod]
        public async Task GetDepartmentById_ReturnsOkResult_WhenDepartmentExists()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var departmentController = BuildDepartmentController(nameDb);
            var id = 1; // Assuming a department with ID 1 exists

            // Act
            var result = await Task.Run(() => departmentController.GetDepartment(id));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(DepartmentDto));
        }

        [TestMethod]
        public async Task GetDepartmentByName_ReturnsOkResult_WhenDepartmentExists()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var departmentController = BuildDepartmentController(nameDb);
            var department = await CreateDepartmentHelper(nameDb, await GenerateDepartment(nameDb));
            var name = department.Name;

            // Act
            var result = await Task.Run(() => departmentController.GetDepartment(name));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(DepartmentDto));
        }

        [TestMethod]
        public async Task CreateDepartment_ReturnsBadRequestResult_WhenDepartmentCreationFails()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var departmentController = BuildDepartmentController(nameDb);
            var department = await GenerateDepartment(nameDb);
            var departmentDto = new DepartmentPostDto
            {
                Name = "",
                CountryId = department.CountryId
            };

            // Act
            departmentController.ModelState.AddModelError("Name", "Required");
            var result = await Task.Run(() => departmentController.CreateDepartment(departmentDto));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task PatchDepartment_ReturnsBadRequestResult_WhenDepartmentUpdateFails()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var departmentController = BuildDepartmentController(nameDb);
            var department = await GenerateDepartment(nameDb);
            var departmentDto = new DepartmentPatchDto
            {
                Name = "",
                CountryId = department.CountryId
            };


            // Act
            departmentController.ModelState.AddModelError("Name", "Required");
            var result = await Task.Run(() => departmentController.PatchDepartment(departmentDto));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task DeleteDepartment_ReturnsNotFoundResult_WhenDepartmentDoesNotExist()
        {
            // Arrange
            var nameDb = Guid.NewGuid().ToString();
            var departmentController = BuildDepartmentController(nameDb);
            var id = 999; // Nonexistent department ID

            // Act
            var result = await Task.Run(() => departmentController.DeleteDepartment(id));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        public static async Task<Department> GenerateDepartment(string nameDb)
        {
            var country = CountryControllerTests.GenerateCountry();
            country = await CountryControllerTests.CreateCountryHelper(nameDb, country);
            return new Department
            {
                Name = UtilHelper.RandomString(6),
                CountryId = country.Id
            };
        }

        public static async Task<Department> CreateDepartmentHelper(string nameDb, Department department)
        {
            var departmentRepository = BuildDepartmentRepository(nameDb);
            await departmentRepository.CreateDeparment(department);
            return await departmentRepository.GetDepartment(department.Id);
        }

        private static DepartmentRepository BuildDepartmentRepository(string nameDb)
        {
            var context = BuildContext(nameDb);
            return new DepartmentRepository(context);
        }

        private static DepartmentService BuildDepartmentService(string nameDb)
        {
            var departmentRepository = BuildDepartmentRepository(nameDb);
            var mapper = ConfigAutoMapper();
            return new DepartmentService(departmentRepository, mapper);
        }

        private static DepartmentController BuildDepartmentController(string nameDb)
        {
            var httpContext = new DefaultHttpContext();
            var departmentService = BuildDepartmentService(nameDb);
            AppUserHelper.MockAuth(httpContext);
            return new DepartmentController(departmentService);
        }
    }
}
