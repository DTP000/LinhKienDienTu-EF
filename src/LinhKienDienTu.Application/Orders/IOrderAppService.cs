using System.Threading.Tasks;
using Abp.Application.Services;
using LinhKienDienTu.Orders.Dto;

namespace LinhKienDienTu.Orders
{
    public interface IOrderAppService : IAsyncCrudAppService<OrderDto, int, PagedOrderResultRequestDto, CreateOrderDto, EditOrderDto>
    {
        Task<OrderDto> GetExtensionsAsync(int id);
    }
}
