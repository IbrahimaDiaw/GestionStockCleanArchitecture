using AutoMapper;
using GestionStock.DAL.Repositories.Interfaces;
using GestionStock.Domain.Entities;
using GestionStock.Infrastructure.Services.Interfaces;
using GestionStock.Shared.Request.Brand;
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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<BrandService> _logger;

        public BrandService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IBrandRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = serviceProvider.GetRequiredService<ILogger<BrandService>>();
        }

        public async Task<BrandResponse> CreateAsync(BrandCreateRequest createRequest)
        {
            BrandEntity entity = _mapper.Map<BrandEntity>(createRequest);
            try
            {
                await _repository.InsertAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Brand creation is failed {ex.Message}");
                throw new NullReferenceException();
            }
 
            return _mapper.Map<BrandResponse>(entity);
        }

        public void DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
            //BrandEntity entity = await _repository.GetByIdAsync(Id);
            //if (entity == null)
            //{
            //    _logger.LogError($"Brand Id {Id} is not found");
            //    throw new KeyNotFoundException("Brand not found");
            //}
            //_repository.DeleteAsync(entity);
        }

        public async Task<List<BrandResponse>> GetAllAsync()
        {
            IEnumerable<BrandEntity> entities = new List<BrandEntity>();
            try
            {
                entities = await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems to retrieve data : {ex.Message}");
                throw new NullReferenceException();
            }
            return _mapper.Map<List<BrandResponse>>(entities);
        }

        public async Task<List<BrandResponse>> GetAllWithProductsAsync()
        {
            IEnumerable<BrandEntity> entities = new List<BrandEntity>();
            try
            {
                entities = await _repository.GetAllWithDependances();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems to retrieve data : {ex.Message}");
                throw new NullReferenceException();
            }
            return _mapper.Map<List<BrandResponse>>(entities);
        }

        public async Task<BrandResponse> GetIdAsync(Guid id)
        {
            BrandEntity entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<BrandResponse>(entity);
        }

        public async Task<BrandResponse> UpdateAsync(Guid Id, BrandUpdateRequest updateRequest)
        {
            BrandEntity entity = await _repository.GetByIdAsync(Id);
            if (entity == null || Id != updateRequest.Id)
            {
                _logger.LogError($"Brand Id {Id} is not found");
                throw new KeyNotFoundException("Brand not found");
            }
            entity = _mapper.Map<BrandEntity>(updateRequest);
            await _repository.UpdateAsync(entity);
            return _mapper.Map<BrandResponse>(entity);
        }
    }
}
