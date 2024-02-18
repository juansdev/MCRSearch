using System.Configuration;
using System.Security.Claims;
using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Mapper;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.DependencyInjection;

namespace MCRSearch.Tests;

public class BaseTests
{
    protected static ApplicationDbContext BuildContext(string nameDb)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(nameDb).Options;
        var dbContext = new ApplicationDbContext(options);
        dbContext.Database.EnsureCreated();

        var modelBuilder = new ModelBuilder(new ConventionSet());
        dbContext.SeedData(modelBuilder);

        return dbContext;
    }

    protected static IMapper ConfigAutoMapper()
    {
        var config = new MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapperProfiles());
        });
        return config.CreateMapper();
    }

    protected WebApplicationFactory<Startup> BuildWebApplicationFactory(string nameDb, bool ignoreSegurity = true)
    {
        var factory = new WebApplicationFactory<Startup>();
        factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                var descriptorDbContext =
                    services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                if (descriptorDbContext != null) services.Remove(descriptorDbContext);

                services.AddDbContext<ApplicationDbContext>(optionsAction => {
                    var options = optionsAction.UseInMemoryDatabase(nameDb).Options;
                    var dbContext = new ApplicationDbContext(options);
                    dbContext.Database.EnsureCreated();
                    var modelBuilder = new ModelBuilder(new ConventionSet());
                    dbContext.SeedData(modelBuilder);
                });
                if (ignoreSegurity)
                {
                    services.AddSingleton<IAuthorizationHandler, AllowAnonymousHandler>();
                    services.AddControllers(options => { options.Filters.Add(new UserFalseFilter()); });
                }
            });
        });
        return factory;
    }
}