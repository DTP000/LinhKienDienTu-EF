using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using LinhKienDienTu.Categories;
using LinhKienDienTu.Controllers;
using LinhKienDienTu.Products;
using LinhKienDienTu.Web.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinhKienDienTu.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProductController : LinhKienDienTuControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;
        public static List<SelectListItem> CategoryItems;

        public ProductController(IProductAppService productAppService, ICategoryAppService categoryAppService)
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
    }

        public async Task<IActionResult> Index()
        {
            CategoryItems = await _categoryAppService.GetSelectListCategoryAsync();
            ViewBag.CategoryItems = CategoryItems;
            return View();
        }

        public async Task<ActionResult> EditModal(int productId)
        {
            var output = await _productAppService.GetAsync(new EntityDto(productId));
            var model = ObjectMapper.Map<EditProductModalViewModel>(output);
            ViewBag.CategoryItems = CategoryItems;
            return PartialView("_EditModal", model);
        }

        public async Task<ActionResult> ViewModal(int productId)
        {
            var output = await _productAppService.GetAsync(new EntityDto(productId));
            var model = ObjectMapper.Map<EditProductModalViewModel>(output);
            ViewBag.CategoryItems = CategoryItems;
            return PartialView("_ViewModal", model);
        }
    }
}
