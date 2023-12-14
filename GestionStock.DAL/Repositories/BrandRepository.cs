using GestionStock.DAL;
using GestionStock.DAL.Repositories.Interfaces;
using GestionStock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.DAL.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly GestionStockDbContext _context;
        public BrandRepository(GestionStockDbContext context)
        {
            _context = context;
        }

        public async Task<BrandEntity> GetByIdAsync(Guid id)
        {
            BrandEntity? entity = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Brand Id {id} doesn't exist ");
            }
            return entity;
        }

        public async Task<IEnumerable<BrandEntity>> GetAllAsync()
        {
            IEnumerable<BrandEntity> brands = await _context.Brands.ToListAsync();
            return brands;
        }

        public async Task<IEnumerable<BrandEntity>> GetAllWithDependances()
        {
            IEnumerable<BrandEntity> brands = await _context.Brands
                    .Include(b => b.Products).ToListAsync();
            return brands;

        }

        public async Task<BrandEntity> InsertAsync(BrandEntity model)
        {
            BrandEntity entity = _context.Brands.Add(model).Entity;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<BrandEntity> UpdateAsync(BrandEntity entity)
        {
            var existingEntity = await _context.Brands.FindAsync(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }
            _context.Brands.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(BrandEntity model)
        {
            _context.Brands.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
