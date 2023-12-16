using GestionStock.Shared.Request.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Shared.Response
{
    public class CategoryResponse : CategoryInputRequest
    {
        public List<ProductResponse> Products { get; set; } = new List<ProductResponse>();
    }
}
