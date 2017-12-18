using MVCGiris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCGiris.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            NorthwindEntities db = new NorthwindEntities();
            var model = db.Categories.ToList();
            return View(model);
        }
    }
}