using System.Web;
using System.Web.Mvc;
using Uyelik.MVC.Services;

namespace Uyelik.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyAuthAttribute());
        }
    }
}
