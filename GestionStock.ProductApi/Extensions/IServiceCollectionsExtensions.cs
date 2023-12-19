using GestionStock.DAL.Repositories.Interfaces;
using GestionStock.DAL.Repositories;
using GestionStock.Shared.Profiles;

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
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                    .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }
    }
}
