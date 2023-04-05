using System.Threading.Tasks;
using Abp.Application.Services;
using LinhKienDienTu.Products.Dto;

namespace LinhKienDienTu.Products
{
    public interface IProductAppService : IAsyncCrudAppService<ProductDto, int, PagedProductResultRequestDto, CreateProductDto, EditProductDto>
    {
    }
}
