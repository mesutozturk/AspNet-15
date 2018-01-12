using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BundleFilterFundamentals.Services
{
    public class ExceptionHandlerFilterAttribute: ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
                return;

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult()
                {
                    ContentType = "application/json",
                    Data = new
                    {
                        name = filterContext.Exception.GetType().Name,
                        message = filterContext.Exception.Message,
                        trace = filterContext.Exception.StackTrace
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.ExceptionHandled = true;
                //Internal Error
            }
            else
            {
                filterContext.ExceptionHandled = true;
                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];
                var data = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
                filterContext.Result = new ViewResult()
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary(data)
                };
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.ExceptionHandled = true;
            }
        }
    }
}