using System;
using System.Collections.Generic;
using System.Text;

namespace GestionStock.Application.DTOs.Common
{
    public class Base : EntityDto<Guid>
    {
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
