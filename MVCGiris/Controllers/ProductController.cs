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
            //ViewData["kategoriler"] = "asd";
            //ViewBag.kategoriler = "asd";
            var kategoriler = new List<SelectListItem>();
            kategoriler.Add(new SelectListItem
            {
                Text = "No Category",
                Value = "null"
            });
            db.Categories
                .OrderBy(x => x.CategoryName)
                .ToList()
                .ForEach(x => kategoriler.Add(new SelectListItem()
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                }));
            ViewBag.Kategoriler = kategoriler;
            return View(urun);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                urun.CategoryID = model.CategoryID;
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