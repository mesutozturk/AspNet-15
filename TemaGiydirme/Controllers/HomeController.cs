using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemaGiydirme.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        #region Partials
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