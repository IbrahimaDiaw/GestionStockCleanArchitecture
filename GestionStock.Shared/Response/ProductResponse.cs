using GestionStock.Shared.Request.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Shared.Response
{
    public class ProductResponse : ProductInputRequest
    {
        public CategoryResponse Category { get; set; } = new CategoryResponse();
        public BrandResponse Brand { get; set; } = new BrandResponse();
    }
}
