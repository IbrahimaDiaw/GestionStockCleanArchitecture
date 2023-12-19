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
        public CategoryResponseWithoutDependencies Category { get; set; }
        public BrandResponseWithoutDependencies Brand { get; set; }
    }

    public class ProductResponseWithoutDependencies : ProductInputRequest
    {
    }


}
