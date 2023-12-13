using AutoMapper;
using GestionStock.Application.DTOs.Category;
using GestionStock.Application.ObjetMetier;
using GestionStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Application.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<CategoryEntity, CategoryOM>().ReverseMap();
            CreateMap<CategoryEntity, CategoryInputDto>().ReverseMap();
            CreateMap<CategoryEntity, CategoryOutputDto>().ReverseMap();
            CreateMap<CategoryEntity, CategoryCreateDto>().ReverseMap();
            CreateMap<CategoryEntity, CategoryUpdateDto>().ReverseMap();

            CreateMap<CategoryCreateDto, CategoryOM>().ReverseMap();
        }
    }
}
