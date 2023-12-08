using GestionStock.Infrastructure.Repositories;
using GestionStock.Infrastructure.Repositories.Interfaces;
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
        }
        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBrandRepository, BrandRepository>()
                    .AddTransient<IProductRepository, ProductRepository>()
                    .AddTransient<ICategoryRepository, CategoryRepository>();
        }
    }
}
