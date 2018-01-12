using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Uyelik.BLL.Account;
using Uyelik.BLL.Repository;
using Uyelik.Entity.Enums;
using Uyelik.Entity.IdentityModels;

namespace Uyelik.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var roleManager = MembershipTools.NewRoleManager();
            var roller = Enum.GetNames(typeof(IdentityRoles));
            foreach (var rol in roller)
            {
                if (!roleManager.RoleExists(rol))
                    roleManager.Create(new ApplicationRole()
                    {
                        Name=rol
                    });
            }

            new MessageRepo();
        }
    }
}
