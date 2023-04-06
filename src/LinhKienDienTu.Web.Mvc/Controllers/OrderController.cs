using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using LinhKienDienTu.Controllers;
using LinhKienDienTu.Orders;
using LinhKienDienTu.Products;
using LinhKienDienTu.Web.Models.Orders;
using LinhKienDienTu.Web.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinhKienDienTu.Web.Controllers
{
    [AbpMvcAuthorize]
    public class OrderController : LinhKienDienTuControllerBase
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IProductAppService _productAppService;
        public static List<SelectListItem> ProductItems;

        public OrderController(IOrderAppService orderAppService, IProductAppService productAppService)
        {
            _orderAppService = orderAppService;
            _productAppService = productAppService;
        }

        public async Task<IActionResult> Index()
        {
            ProductItems = await _productAppService.GetSelectListProductAsync();
            ViewBag.ProductItems = ProductItems;
            return View();
        }

        public async Task<ActionResult> EditModal(int orderId)
        {
            var output = await _orderAppService.GetExtensionsAsync(orderId);
            var model = ObjectMapper.Map<EditOrderModalViewModel>(output);

            return PartialView("_EditModal", model);
        }

        public async Task<ActionResult> ViewModal(int orderId)
        {
            var output = await _orderAppService.GetExtensionsAsync(orderId);
            var model = ObjectMapper.Map<EditOrderModalViewModel>(output);

            return PartialView("_ViewModal", model);
        }
    }
}
