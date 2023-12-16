using GestionStock.DAL.Repositories.Interfaces;
using GestionStock.DAL.Repositories;
using GestionStock.Shared.Profiles;
using GestionStock.ProductApi.Command.Brand;
using GestionStock.Application.Command;

namespace GestionStock.ProductApi.Extensions
{
    public static class IServiceCollectionsExtensions
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
