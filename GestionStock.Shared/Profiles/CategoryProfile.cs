using AutoMapper;
using GestionStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionStock.Shared.Request.Category;
using GestionStock.Shared.Response;

namespace GestionStock.Shared.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<CategoryEntity, CategoryInputRequest>().ReverseMap();
            CreateMap<CategoryEntity, CategoryResponse>().ReverseMap();
            CreateMap<CategoryEntity, CategoryCreateRequest>().ReverseMap();
            CreateMap<CategoryEntity, CategoryUpdateRequest>().ReverseMap();
        }
    }
}
