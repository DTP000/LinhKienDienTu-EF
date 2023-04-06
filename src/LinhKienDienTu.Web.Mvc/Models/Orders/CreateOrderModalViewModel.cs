using Abp.AutoMapper;
using LinhKienDienTu.Orders.Dto;

namespace LinhKienDienTu.Web.Models.Orders
{
    [AutoMapFrom(typeof(CreateOrderDto))]
    public class CreateOrderModalViewModel : CreateOrderDto
    {
    }
}
