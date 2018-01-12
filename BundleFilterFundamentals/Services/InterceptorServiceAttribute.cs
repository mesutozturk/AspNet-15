using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BundleFilterFundamentals.Models;

namespace BundleFilterFundamentals.Services
{
    public class InterceptorServiceAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionParameters != null && context.ActionParameters.Any())
            {
                if (context.ActionParameters.First().Key == "model")
                {
                    var model = context.ActionParameters.First().Value;
                    if (model is LoginViewModel viewModel)
                    {
                        //modeli kontrol edin.
                        viewModel.Falan += 50;
                    }
                }
            }
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            // action ile iş bittikten sonra
        }
    }
}