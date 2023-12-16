using GestionStock.Shared.Request.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Shared.Response
{
    public class BrandResponse : BrandInputRequest
    {
        public List<ProductResponse> Products { get; set; } = new List<ProductResponse>();
    }
}
