using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductInventorySystem.BLL.Services;
using ProductInventorySystem.BLL.Services.Interfaces;
using ProductInventorySystem.DAL.Extensions;

namespace ProductInventorySystem.BLL.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBLLServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDALServices(configuration);

            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
