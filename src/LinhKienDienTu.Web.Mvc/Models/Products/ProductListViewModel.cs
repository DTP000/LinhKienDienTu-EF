using Abp.AutoMapper;
using LinhKienDienTu.Products.Dto;

namespace LinhKienDienTu.Web.Models.Products
{
    [AutoMapFrom(typeof(ProductDto))]
    public class ProductListViewModel : ProductDto
    {
    }
}
