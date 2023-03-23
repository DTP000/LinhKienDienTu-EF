using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LinhKienDienTu.Controllers;

namespace LinhKienDienTu.Web.Controllers
{
    [AbpMvcAuthorize]
    [Area("Admin")]
    public class AboutController : LinhKienDienTuControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
