using GestionStock.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Domain.Entities
{
    [Table("categories")]
    public class CategoryEntity : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }

        public List<ProductEntity> Products { get; set; }
    }
}
