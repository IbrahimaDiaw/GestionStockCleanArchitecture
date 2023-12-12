using GestionStock.Infrastructure.Services;
using GestionStock.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Domain.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddServicesExtenstion(this IServiceCollection services)
        {
            services.AddServices();

        }
        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBrandService, BrandService>()
                    .AddTransient<IProductService, ProductService>()
                    .AddTransient<ICategoryService, CategoryService>();

        }
    }
}
