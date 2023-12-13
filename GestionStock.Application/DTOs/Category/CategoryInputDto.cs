﻿using GestionStock.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Application.DTOs.Category
{
    public class CategoryInputDto : IEntityDto<Guid>
    {
        public virtual Guid Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }
    }
}
