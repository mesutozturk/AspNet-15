using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uyelik.BLL.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Uyelik.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "Admin,User")]
        public ActionResult Mesajlar()
        {
            var model = new MessageRepo().Queryable().Where(x => x.SendBy == HttpContext.User.Identity.GetUserId()).ToList();
            return View(model);
        }
    }
}