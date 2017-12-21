using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemaGiydirme.Models;

namespace TemaGiydirme.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Shop()
        {
            ViewBag.BigTitle = "Ürünler";
            NorthwindContext context = new NorthwindContext();
            var model = context.Products.Take(20).ToList();
            return View(model);
        }
        //public ActionResult Detail(int? productid,bool? active)
        public ActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            NorthwindContext context = new NorthwindContext();
            var urun = context.Products.Find(id.Value);
            if (urun == null)
                return RedirectToAction("Index");

            ViewBag.BigTitle = urun.ProductName;
            return View(urun);
        }
        #region Partials
        public PartialViewResult detailSidebarResult(int categoryid)
        {
            NorthwindContext context = new NorthwindContext();
            var model = context.Products.Where(x => x.CategoryID == categoryid).Take(4).ToList();
            return PartialView("_PartialDetailSidebar",model);
        }
        public PartialViewResult headerResult()
        {
            var model = "Merhaba Partial";
            return PartialView("_PartialHeader", model);
        }
        public PartialViewResult brandingAreaResult()
        {
            return PartialView("_PartialBrandingArea");
        }
        public PartialViewResult mainMenuResult()
        {
            return PartialView("_PartialMainMenu");
        }
        public PartialViewResult sliderResult()
        {
            return PartialView("_PartialSlider");
        }
        public PartialViewResult promoResult()
        {
            return PartialView("_PartialPromo");
        }
        public PartialViewResult brandAreaResult()
        {
            return PartialView("_PartialBrandArea");
        }
        public PartialViewResult productWidgetResult()
        {
            return PartialView("_PartialProductWidget");
        }
        public PartialViewResult footerTopResult()
        {
            return PartialView("_PartialFooterTop");
        }
        public PartialViewResult footerBottomResult()
        {
            return PartialView("_PartialFooterBottom");
        }
        #endregion
    }
}