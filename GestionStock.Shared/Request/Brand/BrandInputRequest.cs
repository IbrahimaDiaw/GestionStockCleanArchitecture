﻿using GestionStock.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Shared.Request.Brand
{
    public class BrandInputRequest : IEntityDto<Guid>
    {
        public virtual Guid Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
