using AutoMapper;
using LinhKienDienTu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinhKienDienTu.Products.Dto
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<EditProductDto, Product>();
            CreateMap<Category, EditProductDto>();
        }
    }
}