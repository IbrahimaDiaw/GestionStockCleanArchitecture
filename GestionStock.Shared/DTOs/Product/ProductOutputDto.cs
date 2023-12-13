using GestionStock.Application.DTOs.Brand;
using GestionStock.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Application.DTOs.Product
{
    public class ProductOutputDto : ProductInputDto
    {
        public CategoryOutputDto Category { get; set; } = new CategoryOutputDto();
        public BrandOutputDto Brand { get; set; } = new BrandOutputDto();
    }
}
