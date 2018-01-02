using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVCCF.Web.Controllers
{
    public class BaseController : Controller
    {
        [NonAction]
        public void ResimBoyutlandir(int en,int boy,string yol)
        {
            WebImage img = new WebImage(yol);
            img.Resize(en, boy, false);
            img.AddTextWatermark("W11.com",fontColor:"Tomato",fontSize:18,fontFamily:"Verdana");
            img.Save(yol);
        }
    }
}