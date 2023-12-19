using AutoMapper;
using GestionStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionStock.Shared.Request.Product;
using GestionStock.Shared.Response;

namespace GestionStock.Shared.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<ProductEntity, ProductCreateRequest>().ReverseMap();
            CreateMap<ProductEntity, ProductInputRequest>().ReverseMap();
            CreateMap<ProductEntity, ProductResponse>().ReverseMap();
            CreateMap<ProductEntity, ProductResponseWithoutDependencies>().ReverseMap();
            CreateMap<ProductEntity, ProductUpdateRequest>().ReverseMap();
        }
    }
}
