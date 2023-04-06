using Abp.AutoMapper;
using LinhKienDienTu.Orders.Dto;

namespace LinhKienDienTu.Web.Models.Orders
{
    [AutoMapFrom(typeof(OrderDto))]
    public class EditOrderModalViewModel : EditOrderDto
    {
    }
}
