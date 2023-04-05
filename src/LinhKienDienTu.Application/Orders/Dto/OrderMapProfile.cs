using AutoMapper;
using LinhKienDienTu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinhKienDienTu.Orders.Dto
{
    public class OrderMapProfile : Profile
    {
        public OrderMapProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<EditOrderDto, Order>();
            CreateMap<Order, EditOrderDto>();

            CreateMap<OrderDetailDto, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailDto>();
        }
    }
}