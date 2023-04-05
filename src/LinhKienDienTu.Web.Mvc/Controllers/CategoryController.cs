using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using LinhKienDienTu.Categories;
using LinhKienDienTu.Controllers;
using LinhKienDienTu.Web.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LinhKienDienTu.Web.Controllers
{
    [AbpMvcAuthorize]
    public class CategoryController : LinhKienDienTuControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int categoryId)
        {
            var output = await _categoryAppService.GetAsync(new EntityDto(categoryId));
            var model = ObjectMapper.Map<EditCategoryModalViewModel>(output);

            return PartialView("_EditModal", model);
        }
    }
}
