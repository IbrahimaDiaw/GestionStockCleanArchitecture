using AutoMapper;
using GestionStock.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using static GestionStock.ProductApi.Command.Brand.BrandCommandHandler;

namespace GestionStock.ProductApi.Command.Brand
{
    public class BrandGeneralCommand<ICommandHandler>
    {
        internal readonly IBrandRepository _repository;
        internal readonly IMapper _mapper;
        internal readonly ILogger<ICommandHandler> _logger;
        internal readonly IUnitOfWork _unitOfWork;
        public BrandGeneralCommand(IServiceProvider serviceProvider) 
        {
            _repository = serviceProvider.GetRequiredService<IBrandRepository>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = serviceProvider.GetRequiredService<ILogger<ICommandHandler>>();
        }
    }
}
