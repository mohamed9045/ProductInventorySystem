using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductInventorySystem.DAL.Data;
using ProductInventorySystem.DAL.Repositories;
using ProductInventorySystem.DAL.Repositories.Interfaces;

namespace ProductInventorySystem.DAL.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDALServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration
                .GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Connection string not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}