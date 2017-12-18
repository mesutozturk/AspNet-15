using MVCGiris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCGiris.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Category");

            NorthwindEntities db = new NorthwindEntities();
            var urun = db.Products.Find(id.Value);
            if (urun == null)
                return View("Error");
            return View(urun);
        }
        [HttpPost]
        public ActionResult Update(Product model)
        {
            if (model == null)
                return View("Error");
            try
            {
                NorthwindEntities db = new NorthwindEntities();
                var urun = db.Products.Find(model.ProductID);
                if (urun == null)
                    return View("Error");
                urun.ProductName = model.ProductName;
                urun.UnitPrice = model.UnitPrice;
                urun.Discontinued = model.Discontinued;
                db.SaveChanges();
                return RedirectToAction("Detail", new { id = urun.ProductID });
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}