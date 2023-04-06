using AutoMapper;
using LinhKienDienTu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VFT.Dashboard.Common;

namespace LinhKienDienTu.Orders.Dto
{
    public class OrderMapProfile : Profile
    {
        public OrderMapProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.NameOrderStatus, opt => opt.MapFrom(src => src.OrderStatus.GetDescription()));
            CreateMap<CreateOrderDto, Order>();
            CreateMap<EditOrderDto, Order>();
            CreateMap<Order, EditOrderDto>();

            CreateMap<OrderDetailDto, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailDto>().ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}