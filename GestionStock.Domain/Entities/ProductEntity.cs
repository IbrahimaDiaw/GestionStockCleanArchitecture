using GestionStock.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Domain.Entities
{
    [Table("products")]
    public class ProductEntity : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public CategoryEntity Category { get; set; }
        public BrandEntity Brand { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

    }
}
