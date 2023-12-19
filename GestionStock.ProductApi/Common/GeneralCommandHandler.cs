using AutoMapper;
using GestionStock.DAL.Repositories.Interfaces;
using GestionStock.Domain.Common.Interfaces;

namespace GestionStock.ProductApi.Common
{
    public class GeneralCommandHandler<TCommandHandler, TEntity>
        where TEntity : class, IEntity
    {
        internal readonly IMapper _mapper;
        internal readonly ILogger<TCommandHandler> _logger;
        internal readonly IUnitOfWork<TEntity> _unitOfWork;
        public GeneralCommandHandler(IServiceProvider serviceProvider)
        {
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork<TEntity>>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = serviceProvider.GetRequiredService<ILogger<TCommandHandler>>();
        }
    }
}
