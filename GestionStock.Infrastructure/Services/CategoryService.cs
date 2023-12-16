using AutoMapper;
using GestionStock.DAL.Repositories.Interfaces;
using GestionStock.Domain.Entities;
using GestionStock.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionStock.Shared.Request.Category;
using GestionStock.Shared.Response;

namespace GestionStock.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(IServiceProvider serviceProvider)
        {
            _repository  = serviceProvider.GetRequiredService<ICategoryRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = serviceProvider.GetRequiredService<ILogger<CategoryService>>();
        }

        public async Task<CategoryResponse> CreateAsync(CategoryCreateRequest createRequest)
        {
            try
            {
                CategoryEntity entity = _mapper.Map<CategoryEntity>(createRequest);
                await _repository.InsertAsync(entity);
                return _mapper.Map<CategoryResponse>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Category creation is failed {ex.Message}");
                throw new NullReferenceException();
            }
        }

        public void DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
            //try
            //{
            //    CategoryEntity entity = await _repository.GetByIdAsync(Id);
            //    if (entity == null)
            //    {
            //        _logger.LogError($"Category Id {Id} is not found");
            //        throw new KeyNotFoundException("Category not found");
            //    }
            //    await _repository.DeleteAsync(entity);
            //} 
            //catch (Exception ex)
            //{
            //    _logger.LogError($"Category Id {Id} element deletion failed : {ex.Message}");
            //    throw new KeyNotFoundException();
            //}
        }

        public async Task<List<CategoryResponse>> GetAllAsync()
        {
            try
            {
                IEnumerable<CategoryEntity> entities = await _repository.GetAllAsync();
                return _mapper.Map<List<CategoryResponse>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems to retrieve data : {ex.Message}");
                throw new ApplicationException();
            }
        }

        public async Task<CategoryResponse> GetIdAsync(Guid id)
        {
            try
            {
                CategoryEntity entity = await _repository.GetByIdAsync(id);
                return _mapper.Map<CategoryResponse>(entity);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Category Key Id {id} not found", ex.Message);
                throw new KeyNotFoundException();
            }
        }

        public async Task<CategoryResponse> UpdateAsync(Guid Id, CategoryUpdateRequest updateRequest)
        {
            try
            {
                CategoryEntity entity = await _repository.GetByIdAsync(Id);
                if (entity == null || Id != updateRequest.Id)
                {
                    _logger.LogError($"Category Id {Id} is not found");
                    throw new KeyNotFoundException();
                }
                entity = _mapper.Map<CategoryEntity>(updateRequest);
                await _repository.UpdateAsync(entity);
                return _mapper.Map<CategoryResponse>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Category Key Id {Id} update failed", ex.Message);
                throw new KeyNotFoundException();
            }
        }
    }
}
