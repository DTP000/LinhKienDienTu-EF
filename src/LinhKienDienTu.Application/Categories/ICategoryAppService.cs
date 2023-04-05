using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using LinhKienDienTu.Categories.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LinhKienDienTu.Categories
{
    public interface ICategoryAppService : IAsyncCrudAppService<CategoryDto, int, PagedCategoryResultRequestDto, CreateCategoryDto, EditCategoryDto>
    {
        Task<List<SelectListItem>> GetSelectListCategoryAsync();
    }
}
