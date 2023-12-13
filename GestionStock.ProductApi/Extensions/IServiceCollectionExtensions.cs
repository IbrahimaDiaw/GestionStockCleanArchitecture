using GestionStock.Application.Profiles;
using GestionStock.DAL.Repositories;
using GestionStock.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.ProductApi.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddRepositoriesExtenstion(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddAutoMapper(typeof(BrandProfile));
        }
        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBrandRepository, BrandRepository>()
                    .AddTransient<IProductRepository, ProductRepository>()
                    .AddTransient<ICategoryRepository, CategoryRepository>()
                    .AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
