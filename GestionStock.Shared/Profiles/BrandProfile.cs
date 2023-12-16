using AutoMapper;
using GestionStock.Domain.Entities;
using GestionStock.Shared.Request.Brand;
using GestionStock.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Shared.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile() 
        { 
            CreateMap<BrandEntity, BrandCreateRequest>().ReverseMap();
            CreateMap<BrandEntity, BrandInputRequest>().ReverseMap();
            CreateMap<BrandEntity, BrandResponse>().ReverseMap();
            CreateMap<BrandEntity, BrandUpdateRequest>().ReverseMap();
        }
    }
}
