using AutoMapper;
using GestionStock.DAL.Repositories.Interfaces;
using GestionStock.Domain.Entities;
using GestionStock.Infrastructure.Services.Interfaces;
using GestionStock.Shared.Request.Product;
using GestionStock.Shared.Response;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        public ProductService(IServiceProvider serviceProvider) 
        {
            _repository = serviceProvider.GetRequiredService<IProductRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = serviceProvider.GetRequiredService<ILogger<ProductService>>();
        }
        public async Task<ProductResponse> CreateAsync(ProductCreateRequest createRequest)
        {
            try { 
 
                ProductEntity entity = _mapper.Map<ProductEntity>(createRequest);
                await _repository.InsertAsync(entity);
                return _mapper.Map<ProductResponse>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Product creation is failed {ex.Message}");
                throw new NullReferenceException();
            }
        }

        public void DeleteAsync(Guid Id)
        {

            throw new NotImplementedException();
            //try
            //{
            //    ProductEntity entity = await _repository.GetByIdAsync(Id);
            //    if (entity == null)
            //    {
            //        _logger.LogError($"Product Id {Id} is not found");
            //        throw new KeyNotFoundException("Product not found");
            //    }
            //    await _repository.DeleteAsync(entity);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"Product Id {Id} element deletion failed : {ex.Message}");
            //    throw new KeyNotFoundException();
            //}
        }

        public async Task<List<ProductResponse>> GetAllAsync()
        {
            try
            {
                IEnumerable<ProductEntity> entities = await _repository.GetAllAsync();
                return _mapper.Map<List<ProductResponse>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems to retrieve data : {ex.Message}");
                throw new ApplicationException();
            }
        }

        public async Task<ProductResponse> GetIdAsync(Guid id)
        {
            try
            {
                ProductEntity entity = await _repository.GetByIdAsync(id);
                return _mapper.Map<ProductResponse>(entity);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Product Key Id {id} not found", ex.Message);
                throw new KeyNotFoundException();
            }
        }

        public async Task<ProductResponse> UpdateAsync(Guid Id, ProductUpdateRequest updateRequest)
        {
            try
            {
                ProductEntity entity = await _repository.GetByIdAsync(Id);
                if (entity == null || Id != updateRequest.Id)
                {
                    _logger.LogError($"Product Id {Id} is not found");
                    throw new KeyNotFoundException();
                }
                entity = _mapper.Map<ProductEntity>(updateRequest);
                await _repository.UpdateAsync(entity);
                return _mapper.Map<ProductResponse>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Product Key Id {Id} update failed", ex.Message);
                throw new KeyNotFoundException();
            }
        }
    }
}
