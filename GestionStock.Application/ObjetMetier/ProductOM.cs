using GestionStock.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Application.ObjetMetier
{
    public class ProductOM : Base
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public CategoryOM Category { get; set; }
        public BrandOM Brand { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
