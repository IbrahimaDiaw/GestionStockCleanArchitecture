﻿using GestionStock.Domain.Entities;
using GestionStock.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly GestionStockDbContext _context;
        public ProductRepository(GestionStockDbContext context)
        {
            _context = context;
        }

        public async Task<ProductEntity> GetByIdAsync(Guid id)
        {
            ProductEntity? entity = await _context.Products.FirstOrDefaultAsync(b => b.Id == id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Product Id {id} doesn't exist ");
            }
            return entity;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            IEnumerable<ProductEntity> products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllWithDependances()
        {
            IEnumerable<ProductEntity> products = await _context.Products
                    .Include(p => p.Brand)
                    .Include(p => p.Category)
                    .ToListAsync();
            return products;

        }

        public async Task<ProductEntity> InsertAsync(ProductEntity model)
        {
            ProductEntity entity = _context.Products.Add(model).Entity;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ProductEntity> UpdateAsync(ProductEntity model)
        {
            _context.Products.Update(model);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return model;
        }

        public async Task DeleteAsync(ProductEntity model)
        {
            _context.Products.Remove(model);
            await _context.SaveChangesAsync();
        }

    }
}