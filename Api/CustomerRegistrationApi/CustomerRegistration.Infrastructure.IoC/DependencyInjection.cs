using CustomerRegistration.Application.Services;
using CustomerRegistration.Application.Services.Interfaces;
using CustomerRegistration.Domain.Interfaces;
using CustomerRegistration.Infrastructure.Data.Context;
using CustomerRegistration.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerRegistration.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            var mySqlConnectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(options =>
                options.UseMySql(mySqlConnectionString,
                    ServerVersion.AutoDetect(mySqlConnectionString),
                    b => b.MigrationsAssembly(typeof(ApplicationContext)
                        .Assembly.FullName)));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}