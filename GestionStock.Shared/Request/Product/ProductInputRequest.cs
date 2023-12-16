using GestionStock.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Shared.Request.Product
{
    public class ProductInputRequest : IEntityDto<Guid>
    {
        public virtual Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
