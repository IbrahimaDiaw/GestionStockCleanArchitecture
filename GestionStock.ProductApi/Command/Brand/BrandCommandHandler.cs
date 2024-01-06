using GestionStock.Application.Command;
using GestionStock.Domain.Entities;
using GestionStock.ProductApi.Common;
using GestionStock.Shared.Response;
using System;
using static GestionStock.ProductApi.Command.Brand.BrandCommand;

namespace GestionStock.ProductApi.Command.Brand
{
    public static class BrandCommandHandler
    {
        public class CreateBrandHandler : GeneralCommandHandler<CreateBrandHandler, BrandEntity>, ICommandHandler<CreateBrandCommand, BrandResponse>
        {
            public CreateBrandHandler(IServiceProvider serviceProvider)
                : base(serviceProvider)
            {
            }
            public async Task<BrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                BrandEntity entity = _mapper.Map<BrandEntity>(request.Brand);
                try
                {
                    await _unitOfWork.Repository.InsertAsync(entity);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Brand creation is failed {ex.Message}");
                    throw new NullReferenceException();
                }

                return _mapper.Map<BrandResponse>(entity);
            }
        }
        public class GetByIdBrandHandler : GeneralCommandHandler<GetByIdBrandHandler, BrandEntity>, ICommandHandler<GetBrandCommand, BrandResponse>
        {
            public GetByIdBrandHandler(IServiceProvider serviceProvider) 
                : base(serviceProvider)
            {
            }

            public async Task<BrandResponse> Handle(GetBrandCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    BrandEntity entity = await _unitOfWork.Repository.GetByIdAsync(request.Id);
                    return _mapper.Map<BrandResponse>(entity);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Brand Id {request.Id} is not found : {ex.Message}");
                    throw new KeyNotFoundException();
                }
            }
        }
        public class UpdateBrandHandler : GeneralCommandHandler<UpdateBrandHandler, BrandEntity>, ICommandHandler<UpdateBrandCommand, BrandResponse>
        {
            public UpdateBrandHandler(IServiceProvider serviceProvider) 
                : base(serviceProvider)
            {
            }

            public async Task<BrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                try
                {

                    BrandEntity entity = await _unitOfWork.Repository.GetByIdAsync(request.Id);
                    if (entity == null || request.Id != request.Brand.Id)
                    {
                        _logger.LogError($"Brand Id {request.Id} is not found");
                        throw new KeyNotFoundException("Brand not found");
                    }
                    entity = _mapper.Map<BrandEntity>(request.Brand);
                    await _unitOfWork.Repository.UpdateAsync(entity);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<BrandResponse>(entity);

                }
                catch
                {
                    throw new KeyNotFoundException("Brand not found");
                }
            }
        }

        public class GetAllBrandCommandHandler : GeneralCommandHandler<GetAllBrandCommandHandler, BrandEntity>, ICommandHandler<GetAllBrandCommand, List<BrandResponse>>
        {
            public GetAllBrandCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }

            public async Task<List<BrandResponse>> Handle(GetAllBrandCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var entities = await _unitOfWork.Repository.GetAllAsync();
                    return _mapper.Map<List<BrandResponse>>(entities);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Problems to retrieve data : {ex.Message}");
                    throw new NullReferenceException();
                }
            }
        }

        public class DeleteBrandCommandHandler : GeneralCommandHandler<DeleteBrandCommandHandler, BrandEntity>, ICommandHandler<DeleteCommand, bool>
        {
            public DeleteBrandCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }
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
