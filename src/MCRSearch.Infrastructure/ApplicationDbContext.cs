using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Core.Entities.Commons;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Macs;

namespace MCRSearch.src.MCRSearch.Infrastructure
{
    public class ApplicationDbContext: IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<BaseEntity>();
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ROLE_ID = "341743f0-asd2-42de-afbf-59kmkkmk72cf6";

            //seed admin role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            var appUser = new AppUser
            {
                Id = ADMIN_ID,
                Email = "admin@admin.com",
                EmailConfirmed = true,
                Name = "admin",
                UserName = "admin",
             NormalizedUserName = "ADMIN"
            };

            //set user password
            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "Admin123*");

            //seed user
            modelBuilder.Entity<AppUser>().HasData(appUser);

            //set user role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            // Seed Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Colombia" },
                new Country { Id = 2, Name = "Brazil" }
            );

            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, CountryId = 1, Name = "Cundinamarca" },
                new Department { Id = 2, CountryId = 2, Name = "Goiás" }
            );

            // Seed Cities
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, DepartmentId = 1, Name = "Bogotá D.C." },
                new City { Id = 2, DepartmentId = 1, Name = "Tunja" },
                new City { Id = 3, DepartmentId = 2, Name = "Brasilia" },
                new City { Id = 4, DepartmentId = 2, Name = "Goiânia" }
            );

            // Seed Vehicle Brands
            modelBuilder.Entity<VehicleBrand>().HasData(
                new VehicleBrand { Id = 1, Name = "Toyota" },
                new VehicleBrand { Id = 2, Name = "Honda" },
                new VehicleBrand { Id = 3, Name = "Ford" },
                new VehicleBrand { Id = 4, Name = "Chevrolet" },
                new VehicleBrand { Id = 5, Name = "Nissan" },
                new VehicleBrand { Id = 6, Name = "Jeep" },
                new VehicleBrand { Id = 7, Name = "Volkswagen" },
                new VehicleBrand { Id = 8, Name = "BMW" },
                new VehicleBrand { Id = 9, Name = "Mercedes-Benz" },
                new VehicleBrand { Id = 10, Name = "Subaru" },
                new VehicleBrand { Id = 11, Name = "Ford" },
                new VehicleBrand { Id = 12, Name = "Tesla" },
                new VehicleBrand { Id = 13, Name = "GMC" },
                new VehicleBrand { Id = 14, Name = "Audi" },
                new VehicleBrand { Id = 15, Name = "Hyundai" },
                new VehicleBrand { Id = 16, Name = "Lexus" },
                new VehicleBrand { Id = 17, Name = "Kia" },
                new VehicleBrand { Id = 18, Name = "Jaguar" },
                new VehicleBrand { Id = 19, Name = "Land Rover" },
                new VehicleBrand { Id = 20, Name = "Ford" }
            );

            // Seed Vehicle Models
            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel { Id = 1, Name = "Camry" },
                new VehicleModel { Id = 2, Name = "Accord" },
                new VehicleModel { Id = 3, Name = "Explorer" },
                new VehicleModel { Id = 4, Name = "Malibu" },
                new VehicleModel { Id = 5, Name = "Rogue" },
                new VehicleModel { Id = 6, Name = "Wrangler" },
                new VehicleModel { Id = 7, Name = "Golf" },
                new VehicleModel { Id = 8, Name = "X5" },
                new VehicleModel { Id = 9, Name = "C-Class" },
                new VehicleModel { Id = 10, Name = "Outback" },
                new VehicleModel { Id = 11, Name = "F-150" },
                new VehicleModel { Id = 12, Name = "Model S" },
                new VehicleModel { Id = 13, Name = "Sierra" },
                new VehicleModel { Id = 14, Name = "Q7" },
                new VehicleModel { Id = 15, Name = "Santa Fe" },
                new VehicleModel { Id = 16, Name = "RX" },
                new VehicleModel { Id = 17, Name = "Sportage" },
                new VehicleModel { Id = 18, Name = "F-PACE" },
                new VehicleModel { Id = 19, Name = "Discovery" },
                new VehicleModel { Id = 20, Name = "Mustang" }
            );

            // Seed Vehicle Types
            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType { Id = 1, Name = "Automóvil" },
                new VehicleType { Id = 2, Name = "Camioneta" },
                new VehicleType { Id = 3, Name = "SUV" },
                new VehicleType { Id = 4, Name = "Campero" }
            );

            // Seed Vehicles
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, VehicleBrandId = 1, VehicleModelId = 1, VehicleTypeId = 1 },
                new Vehicle { Id = 2, VehicleBrandId = 2, VehicleModelId = 2, VehicleTypeId = 1 },
                new Vehicle { Id = 3, VehicleBrandId = 3, VehicleModelId = 3, VehicleTypeId = 2 },
                new Vehicle { Id = 4, VehicleBrandId = 4, VehicleModelId = 4, VehicleTypeId = 1 },
                new Vehicle { Id = 5, VehicleBrandId = 5, VehicleModelId = 5, VehicleTypeId = 3 },
                new Vehicle { Id = 6, VehicleBrandId = 6, VehicleModelId = 6, VehicleTypeId = 4 },
                new Vehicle { Id = 7, VehicleBrandId = 7, VehicleModelId = 7, VehicleTypeId = 1 },
                new Vehicle { Id = 8, VehicleBrandId = 8, VehicleModelId = 8, VehicleTypeId = 3 },
                new Vehicle { Id = 9, VehicleBrandId = 9, VehicleModelId = 9, VehicleTypeId = 1 },
                new Vehicle { Id = 10, VehicleBrandId = 10, VehicleModelId = 10, VehicleTypeId = 2 },
                new Vehicle { Id = 11, VehicleBrandId = 11, VehicleModelId = 11, VehicleTypeId = 2 },
                new Vehicle { Id = 12, VehicleBrandId = 12, VehicleModelId = 12, VehicleTypeId = 1 },
                new Vehicle { Id = 13, VehicleBrandId = 13, VehicleModelId = 13, VehicleTypeId = 2 },
                new Vehicle { Id = 14, VehicleBrandId = 14, VehicleModelId = 14, VehicleTypeId = 2 },
                new Vehicle { Id = 15, VehicleBrandId = 15, VehicleModelId = 15, VehicleTypeId = 3 },
                new Vehicle { Id = 16, VehicleBrandId = 16, VehicleModelId = 16, VehicleTypeId = 3 },
                new Vehicle { Id = 17, VehicleBrandId = 17, VehicleModelId = 17, VehicleTypeId = 3 },
                new Vehicle { Id = 18, VehicleBrandId = 18, VehicleModelId = 18, VehicleTypeId = 3 },
                new Vehicle { Id = 19, VehicleBrandId = 19, VehicleModelId = 19, VehicleTypeId = 3 },
                new Vehicle { Id = 20, VehicleBrandId = 20, VehicleModelId = 20, VehicleTypeId = 1 }
            );

            // Seed Available Vehicles
            // Seed Available Vehicles
            modelBuilder.Entity<AvailableVehicle>().HasData(
                new AvailableVehicle { Id = 1, VehicleId = 1, PickUpCityId = 1, ReturnCityId = 1 },
                new AvailableVehicle { Id = 2, VehicleId = 2, PickUpCityId = 1, ReturnCityId = 1 },
                new AvailableVehicle { Id = 3, VehicleId = 3, PickUpCityId = 1, ReturnCityId = 1 },
                new AvailableVehicle { Id = 4, VehicleId = 2, PickUpCityId = 1, ReturnCityId = 1 },
                new AvailableVehicle { Id = 5, VehicleId = 5, PickUpCityId = 1, ReturnCityId = 1 },
                new AvailableVehicle { Id = 6, VehicleId = 6, PickUpCityId = 1, ReturnCityId = 2 },
                new AvailableVehicle { Id = 7, VehicleId = 5, PickUpCityId = 1, ReturnCityId = 2 },
                new AvailableVehicle { Id = 8, VehicleId = 8, PickUpCityId = 2, ReturnCityId = 1 },
                new AvailableVehicle { Id = 9, VehicleId = 5, PickUpCityId = 3, ReturnCityId = 3 },
                new AvailableVehicle { Id = 10, VehicleId = 10, PickUpCityId = 3, ReturnCityId = 3 },
                new AvailableVehicle { Id = 11, VehicleId = 14, PickUpCityId = 3, ReturnCityId = 3 },
                new AvailableVehicle { Id = 12, VehicleId = 3, PickUpCityId = 3, ReturnCityId = 3 },
                new AvailableVehicle { Id = 13, VehicleId = 12, PickUpCityId = 4, ReturnCityId = 3 },
                new AvailableVehicle { Id = 14, VehicleId = 14, PickUpCityId = 4, ReturnCityId = 3 },
                new AvailableVehicle { Id = 15, VehicleId = 20, PickUpCityId = 4, ReturnCityId = 3 },
                new AvailableVehicle { Id = 16, VehicleId = 1, PickUpCityId = 4, ReturnCityId = 3 },
                new AvailableVehicle { Id = 17, VehicleId = 17, PickUpCityId = 2, ReturnCityId = 2 },
                new AvailableVehicle { Id = 18, VehicleId = 14, PickUpCityId = 2, ReturnCityId = 2 },
                new AvailableVehicle { Id = 19, VehicleId = 19, PickUpCityId = 2, ReturnCityId = 2 },
                new AvailableVehicle { Id = 20, VehicleId = 20, PickUpCityId = 4, ReturnCityId = 4 }
            );
        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<AvailableVehicle> AvailableVehicles { get; set; }
    }
}
