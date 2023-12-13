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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GestionStockDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryRepository(GestionStockDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryEntity> GetByIdAsync(Guid id)
        {
            CategoryEntity? entity = await _context.Categories.FirstOrDefaultAsync(b => b.Id == id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Category Id {id} doesn't exist ");
            }
            return entity;
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllAsync()
        {
            IEnumerable<CategoryEntity> Categories = await _context.Categories
                    .ToListAsync();
            return Categories;
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllWithDependances()
        {
            IEnumerable<CategoryEntity> Categories = await _context.Categories
                    .Include(c => c.Products)
                    .ToListAsync();
            return Categories;

        }

        public async Task<CategoryEntity> InsertAsync(CategoryEntity model)
        {
            CategoryEntity entity = _context.Categories.Add(model).Entity;
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<CategoryEntity> UpdateAsync(CategoryEntity model)
        {
            var existingEntity = await _context.Categories.FindAsync(model.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }
            _context.Categories.Update(model);
            await _unitOfWork.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(CategoryEntity model)
        {
            _context.Categories.Remove(model);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
