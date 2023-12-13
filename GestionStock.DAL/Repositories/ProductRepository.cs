﻿using GestionStock.DAL;
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
    public class ProductRepository : IProductRepository
    {
        private readonly GestionStockDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public ProductRepository(GestionStockDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
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
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<ProductEntity> UpdateAsync(ProductEntity model)
        {
            _context.Products.Update(model);
            await _unitOfWork.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(ProductEntity model)
        {
            _context.Products.Remove(model);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetProduitsByIdCategory(Guid id)
        {
            IEnumerable<ProductEntity> products = await _context.Products.Where(p => p.CategoryId == id).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<ProductEntity>> GetProduitsByIdBrand(Guid bandId)
        {
            IEnumerable<ProductEntity> products = await _context.Products.Where(p => p.BrandId == bandId).ToListAsync();
            return products;
        }
    }
}