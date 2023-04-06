using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LinhKienDienTu.Controllers;
using System;
using Microsoft.EntityFrameworkCore;

namespace LinhKienDienTu.Web.Client.Controllers
{
    [Area("Client")]
    public class ProductsController : LinhKienDienTuControllerBase
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
