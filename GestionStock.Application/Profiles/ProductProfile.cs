using AutoMapper;
using GestionStock.Application.DTOs.Product;
using GestionStock.Application.ObjetMetier;
using GestionStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<ProductEntity, ProductCreateDto>().ReverseMap();
            CreateMap<ProductEntity, ProductOM>().ReverseMap();
            CreateMap<ProductEntity, ProductInputDto>().ReverseMap();
            CreateMap<ProductEntity, ProductOutputDto>()
                .ForMember(dto => dto.Brand, options => options.MapFrom(entity => entity.Brand))
                .ForMember(dto => dto.Category, options => options.MapFrom(entity => entity.Category))
                .ReverseMap();
            CreateMap<ProductEntity, ProductUpdateDto>().ReverseMap();
            CreateMap<ProductCreateDto, ProductOM>().ReverseMap();
        }
    }
}
