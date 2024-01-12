using GestionStock.Application.Command;
using GestionStock.Domain.Entities;
using GestionStock.ProductApi.Common;
using GestionStock.Shared.Response;
using Microsoft.EntityFrameworkCore;
using System;
using static GestionStock.ProductApi.Command.Product.ProductCommand;

namespace GestionStock.ProductApi.Command.Product
{
    public static class ProductCommandHandler
    {
        public class CreateProductHandler : GeneralCommandHandler<CreateProductHandler, ProductEntity>, ICommandHandler<CreateProductCommand, ProductResponse>
        {
            public CreateProductHandler(IServiceProvider serviceProvider)
                : base(serviceProvider)
            {
            }
            public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                ProductEntity entity = _mapper.Map<ProductEntity>(request.Product);
                try
                {
                    await _unitOfWork.Repository.InsertAsync(entity);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Product creation is failed {ex.Message}");
                    throw new NullReferenceException();
                }

                return _mapper.Map<ProductResponse>(entity);
            }
        }
        public class GetByIdProductHandler : GeneralCommandHandler<GetByIdProductHandler, ProductEntity>, ICommandHandler<GetProductCommand, ProductResponse>
        {
            public GetByIdProductHandler(IServiceProvider serviceProvider) 
                : base(serviceProvider)
            {
            }

            public async Task<ProductResponse> Handle(GetProductCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    ProductEntity entity = await _unitOfWork.Repository.GetByIdAsync(request.Id);
                    return _mapper.Map<ProductResponse>(entity);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Product Id {request.Id} is not found : {ex.Message}");
                    throw new KeyNotFoundException();
                }
            }
        }
        public class UpdateProductHandler : GeneralCommandHandler<UpdateProductHandler, ProductEntity>, ICommandHandler<UpdateProductCommand, ProductResponse>
        {
            public UpdateProductHandler(IServiceProvider serviceProvider) 
                : base(serviceProvider)
            {
            }

            public async Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                try
                {

                    ProductEntity entity = await _unitOfWork.Repository.GetByIdAsync(request.Id);
                    if (entity == null || request.Id != request.Product.Id)
                    {
                        _logger.LogError($"Product Id {request.Id} is not found");
                        throw new KeyNotFoundException("Product not found");
                    }
                    entity = _mapper.Map<ProductEntity>(request.Product);
                    await _unitOfWork.Repository.UpdateAsync(entity);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<ProductResponse>(entity);

                }
                catch
                {
                    throw new KeyNotFoundException("Product not found");
                }
            }
        }

        public class GetAllProductCommandHandler : GeneralCommandHandler<GetAllProductCommandHandler, ProductEntity>, ICommandHandler<GetAllProductCommand, List<ProductResponse>>
        {
            public GetAllProductCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }

            public async Task<List<ProductResponse>> Handle(GetAllProductCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var entities = (await _unitOfWork.Repository.GetAllAsync())
                        .Include(p => p.Category)
                        .Include(p => p.Brand)
                        .ToList();

                    return _mapper.Map<List<ProductResponse>>(entities);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Problems to retrieve data : {ex.Message}");
                    throw new NullReferenceException();
                }
            }
        }

        public class DeleteProductCommandHandler : GeneralCommandHandler<DeleteProductCommandHandler, ProductEntity>, ICommandHandler<DeleteCommand, bool>
        {
            public DeleteProductCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }
            public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var entity = await _unitOfWork.Repository.GetByIdAsync(request.Id);
                    var result = await _unitOfWork.Repository.DeleteAsync(entity);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Brand Id {request.Id} is not found");
                    throw new KeyNotFoundException("Brand not found", ex);
                }
            }
        }
    }
}
