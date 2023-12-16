using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionStock.Shared.Request.Product
{
    public class ProductCreateRequest : ProductInputRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
