using AutoMapper;
using PAPI.Core.DTOs;
using PAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Brand ,BrandDto>().ReverseMap();
            CreateMap<ProductPhoto, ProductPhotoDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
            CreateMap<BrandUpdateDto, Brand>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
            CreateMap<ProductWithBrandCategoryAndPhotos, Product>().ReverseMap();
            CreateMap<Product, ProductWithBrandCategoryAndPhotos>().ReverseMap();
            CreateMap<ProductDto, ProductWithBrandCategoryAndPhotos>().ReverseMap();
            CreateMap<ProductWithBrandCategoryAndPhotos, ProductDto>().ReverseMap();
            CreateMap<Category,CategoryViewDto>().ForMember(dest => dest.ParentName, opt => opt.MapFrom(s=>s.Parent.Name));
            
        }
    }
}
