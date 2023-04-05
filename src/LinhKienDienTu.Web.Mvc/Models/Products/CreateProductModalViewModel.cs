using Abp.AutoMapper;
using LinhKienDienTu.Products.Dto;

namespace LinhKienDienTu.Web.Models.Products
{
    [AutoMapFrom(typeof(CreateProductDto))]
    public class CreateProductModalViewModel : CreateProductDto
    {
    }
}
