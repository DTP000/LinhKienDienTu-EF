using System.Threading.Tasks;
using Abp.Application.Services;
using LinhKienDienTu.Categories.Dto;

namespace LinhKienDienTu.Categories
{
    public interface ICategoryAppService : IAsyncCrudAppService<CategoryDto, int, PagedCategoryResultRequestDto, CreateCategoryDto, EditCategoryDto>
    {
    }
}
