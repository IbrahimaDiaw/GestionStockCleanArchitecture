using GestionStock.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Application.DTOs.Category
{
    public class CategoryOutputDto : CategoryInputDto
    {
        public List<ProductOutputDto> Products { get; set; } = new List<ProductOutputDto>();
    }
}
