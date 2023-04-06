using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LinhKienDienTu.Controllers;

namespace LinhKienDienTu.Web.Client.Controllers
{
    [Area("Client")]
    public class OrderController : LinhKienDienTuControllerBase
    {
        public ActionResult Cart()
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
