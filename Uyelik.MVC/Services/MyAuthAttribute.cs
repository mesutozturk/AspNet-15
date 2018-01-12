using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Uyelik.Entity.ViewModels;

namespace Uyelik.MVC.Services
{
    public class MyAuthAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.Result = CreateResult(filterContext);
        }
        protected ActionResult CreateResult(AuthorizationContext filterContext)
        {
            var controllerContext = new ControllerContext(filterContext.RequestContext, filterContext.Controller);
            var controller = (string)filterContext.RouteData.Values["controller"];
            var action = (string)filterContext.RouteData.Values["action"];
            // any custom model here
            var model = new ProfileViewModel();

            if (HttpContext.Current.User.IsInRole("Passive"))
            {
                // custom logic to determine proper view here - i'm just hardcoding it
                var viewName = "~/Account/Profile.cshtml";

                return new ViewResult
                {
                    ViewName = viewName,
                    ViewData = new ViewDataDictionary<ProfileViewModel>(model)
                };
            }

            return new ViewResult
            {
                ViewName = "~/",
                ViewData = new ViewDataDictionary<ProfileViewModel>(model)
            };

        }

        public string Kamil { get; set; }
    }
}