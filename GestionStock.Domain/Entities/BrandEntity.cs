using GestionStock.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Domain.Entities
{
    [Table("brands")]
    public class BrandEntity : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [InverseProperty("Brand")]
        public List<ProductEntity> Products { get; set; }

        //public string Test { get; set; }
    }
}
