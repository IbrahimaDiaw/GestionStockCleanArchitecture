using AutoMapper;
using GestionStock.Application.DTOs.Brand;
using GestionStock.Application.ObjetMetier;
using GestionStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Application.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile() 
        { 
            CreateMap<BrandEntity, BrandOM>().ReverseMap();
            CreateMap<BrandEntity, BrandCreateDto>().ReverseMap();
            CreateMap<BrandEntity, BrandInputDto>().ReverseMap();
            CreateMap<BrandEntity, BrandOutputDto>().ReverseMap();
            CreateMap<BrandEntity, BrandUpdateDto>().ReverseMap();
            CreateMap<BrandCreateDto, BrandOM>().ReverseMap();
        }
    }
}
