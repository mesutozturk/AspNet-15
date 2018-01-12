using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BundleFilterFundamentals.Services;

namespace BundleFilterFundamentals.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionHandlerFilterAttribute());
            filters.Add(new InterceptorServiceAttribute());
        }
    }
}