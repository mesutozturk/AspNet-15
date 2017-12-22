using SepetUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SepetUygulamasi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult UrunleriGetir()
        {
            NorthContext db = new NorthContext();
            var model = db.Products.Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.UnitPrice,
                x.Category.CategoryName,
                x.UnitsInStock,
                x.Discontinued,
                x.Supplier.CompanyName
            }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}