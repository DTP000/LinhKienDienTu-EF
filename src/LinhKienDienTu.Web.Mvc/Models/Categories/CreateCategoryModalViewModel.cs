using Abp.AutoMapper;
using LinhKienDienTu.Categories.Dto;

namespace LinhKienDienTu.Web.Models.Categories
{
    [AutoMapFrom(typeof(CreateCategoryDto))]
    public class CreateCategoryModalViewModel : CreateCategoryDto
    {
    }
}
