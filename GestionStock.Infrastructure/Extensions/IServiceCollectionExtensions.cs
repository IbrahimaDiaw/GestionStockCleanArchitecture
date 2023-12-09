using GestionStock.Application.DTOs.Brand;
using GestionStock.Infrastructure.Repositories;
using GestionStock.Infrastructure.Repositories.Interfaces;
using GestionStock.Infrastructure.Services;
using GestionStock.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddServicesExtenstion(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddServices();
            services.AddAutoMapper(typeof(BrandCreateDto));
        }
        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBrandRepository, BrandRepository>()
                    .AddTransient<IProductRepository, ProductRepository>()
                    .AddTransient<ICategoryRepository, CategoryRepository>();
        }
        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBrandService, BrandService>()
                    .AddTransient<IProductService, ProductService>()
                    .AddTransient<ICategoryService, CategoryService>();

        }
    }
}
