using GestionStock.Application.Command;
using GestionStock.Domain.Entities;
using GestionStock.ProductApi.Common;
using GestionStock.Shared.Response;
using System;
using static GestionStock.ProductApi.Command.Category.CategoryCommand;

namespace GestionStock.ProductApi.Command.Category
{
    public static class CategoryCommandHandler
    {
        public class CreateCategoryHandler : GeneralCommandHandler<CreateCategoryHandler, CategoryEntity>, ICommandHandler<CreateCategoryCommand, CategoryResponse>
        {
            public CreateCategoryHandler(IServiceProvider serviceProvider)
                : base(serviceProvider)
            {
            }
            public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                CategoryEntity entity = _mapper.Map<CategoryEntity>(request.Category);
                try
                {
                    await _unitOfWork.Repository.InsertAsync(entity);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Category creation is failed {ex.Message}");
                    throw new NullReferenceException();
                }

                return _mapper.Map<CategoryResponse>(entity);
            }
        }
        public class GetByIdCategoryHandler : GeneralCommandHandler<GetByIdCategoryHandler, CategoryEntity>, ICommandHandler<GetCategoryCommand, CategoryResponse>
        {
            public GetByIdCategoryHandler(IServiceProvider serviceProvider) 
                : base(serviceProvider)
            {
            }

            public async Task<CategoryResponse> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    CategoryEntity entity = await _unitOfWork.Repository.GetByIdAsync(request.Id);
                    return _mapper.Map<CategoryResponse>(entity);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Category Id {request.Id} is not found : {ex.Message}");
                    throw new KeyNotFoundException();
                }
            }
        }
        public class UpdateCategoryHandler : GeneralCommandHandler<UpdateCategoryHandler, CategoryEntity>, ICommandHandler<UpdateCategoryCommand, CategoryResponse>
        {
            public UpdateCategoryHandler(IServiceProvider serviceProvider) 
                : base(serviceProvider)
            {
            }

            public async Task<CategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                try
                {

                    CategoryEntity entity = await _unitOfWork.Repository.GetByIdAsync(request.Id);
                    if (entity == null || request.Id != request.Category.Id)
                    {
                        _logger.LogError($"Category Id {request.Id} is not found");
                        throw new KeyNotFoundException("Category not found");
                    }
                    entity = _mapper.Map<CategoryEntity>(request.Category);
                    await _unitOfWork.Repository.UpdateAsync(entity);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<CategoryResponse>(entity);

                }
                catch
                {
                    throw new KeyNotFoundException("Category not found");
                }
            }
        }

        public class GetAllCategoryCommandHandler : GeneralCommandHandler<GetAllCategoryCommandHandler, CategoryEntity>, ICommandHandler<GetAllCategoryCommand, List<CategoryResponse>>
        {
            public GetAllCategoryCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }

            public async Task<List<CategoryResponse>> Handle(GetAllCategoryCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var entities = await _unitOfWork.Repository.GetAllAsync();
                    return _mapper.Map<List<CategoryResponse>>(entities);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Problems to retrieve data : {ex.Message}");
                    throw new NullReferenceException();
                }
            }
        }
        public class DeleteCategoryCommandHandler : GeneralCommandHandler<DeleteCategoryCommandHandler, CategoryEntity>, ICommandHandler<DeleteCommand, bool>
        {
            public DeleteCategoryCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }
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
