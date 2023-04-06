using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LinhKienDienTu.Controllers;

namespace LinhKienDienTu.Web.Client.Controllers
{
    [Area("Client")]
    public class CategoriesController : LinhKienDienTuControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(id);
        }
    }
    
}
