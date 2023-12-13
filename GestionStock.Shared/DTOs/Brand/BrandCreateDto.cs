using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionStock.Application.DTOs.Brand
{
    public class BrandCreateDto : BrandInputDto
    {
        [JsonIgnore]
        public Guid Id {  get; set; } = Guid.NewGuid();
    }
}
