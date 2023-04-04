using Abp.AutoMapper;
using LinhKienDienTu.Categories.Dto;

namespace LinhKienDienTu.Web.Models.Categories
{
    [AutoMapFrom(typeof(CategoryDto))]
    public class CategoryListViewModel : CategoryDto
    {
    }
}
