using GestionStock.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Application.ObjetMetier
{
    public class BrandOM : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductOM> Products { get; set; } 
    }
}
