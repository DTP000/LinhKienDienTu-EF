using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LinhKienDienTu.Controllers;

namespace LinhKienDienTu.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : LinhKienDienTuControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
