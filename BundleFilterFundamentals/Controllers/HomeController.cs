using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BundleFilterFundamentals.Models;
using BundleFilterFundamentals.Services;

namespace BundleFilterFundamentals.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [InterceptorService]
        public ActionResult Giris(LoginViewModel model)
        {
            return View();
        }
    }
}