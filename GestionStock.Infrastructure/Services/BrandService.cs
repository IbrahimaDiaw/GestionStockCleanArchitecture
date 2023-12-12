using AutoMapper;
using GestionStock.Application.DTOs.Brand;
using GestionStock.Application.ObjetMetier;
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

        public async Task<BrandOutputDto> CreateAsync(BrandCreateDto createDto)
        {
            BrandOM brandOM = _mapper.Map<BrandOM>(createDto);
            BrandEntity entity = _mapper.Map<BrandEntity>(brandOM);
            try
            {
                await _repository.InsertAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Brand creation is failed {ex.Message}");
            }
 
            return _mapper.Map<BrandOutputDto>(entity);
        }

        public async Task DeleteAsync(Guid Id)
        {
            BrandEntity entity = await _repository.GetByIdAsync(Id);
            if (entity == null)
            {
                _logger.LogError($"Brand Id {Id} is not found");
                throw new KeyNotFoundException("Brand not found");
            }
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<BrandOutputDto>> GetAllAsync()
        {
            IEnumerable<BrandEntity> entities = new List<BrandEntity>();
            try
            {
                entities = await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems to retrieve data : {ex.Message}");
            }
            return _mapper.Map<List<BrandOutputDto>>(entities);
        }

        public async Task<List<BrandOutputDto>> GetAllWithProductsAsync()
        {
            IEnumerable<BrandEntity> entities = new List<BrandEntity>();
            try
            {
                entities = await _repository.GetAllWithDependances();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems to retrieve data : {ex.Message}");
            }
            return _mapper.Map<List<BrandOutputDto>>(entities);
        }

        public async Task<BrandOutputDto> GetIdAsync(Guid id)
        {
            BrandEntity entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<BrandOutputDto>(entity);
        }

        public async Task<BrandOutputDto> UpdateAsync(Guid Id, BrandUpdateDto updateDto)
        {
            BrandEntity entity = await _repository.GetByIdAsync(Id);
            if (entity == null || Id != updateDto.Id)
            {
                _logger.LogError($"Brand Id {Id} is not found");
                throw new KeyNotFoundException("Brand not found");
            }
            entity = _mapper.Map<BrandEntity>(updateDto);
            await _repository.UpdateAsync(entity);
            return _mapper.Map<BrandOutputDto>(entity);
        }
    }
}
