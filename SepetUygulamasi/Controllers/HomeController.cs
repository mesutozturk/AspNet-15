using SepetUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SepetUygulamasi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult UrunleriGetir()
        {
            NorthContext db = new NorthContext();
            var model = db.Products.Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.UnitPrice,
                x.Category.CategoryName,
                x.UnitsInStock,
                x.Discontinued,
                x.Supplier.CompanyName
            }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SiparisOlustur(List<SiparisViewModel> model)
        {
            if (model == null)
                return Json("",JsonRequestBehavior.AllowGet);
            NorthContext db = new NorthContext();
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    var siparis = new Order()
                    {
                        CustomerID = "DUMON",
                        EmployeeID = 1,
                        OrderDate = DateTime.Now,
                        RequiredDate = DateTime.Now.AddDays(7),
                        ShipVia = 1,
                        Freight = 59,
                        ShipName = "Lucky S",
                        ShipRegion = "Çorum",
                        ShipCity = "Sungurlu",
                        ShipCountry = "USÇ"
                    };
                    db.Orders.Add(siparis);
                    db.SaveChanges();
                    foreach (var item in model)
                    {
                        db.Order_Details.Add(new Order_Detail
                        {
                            OrderID = siparis.OrderID,
                            ProductID = item.ProductID,
                            Discount = 0,
                            Quantity = item.Count,
                            UnitPrice = item.UnitPrice
                        });
                    }
                    db.SaveChanges();
                    tran.Commit();
                    var msg = new
                    {
                        success = true,
                        message = $"{siparis.OrderID} nolu sipariş başarıyla oluşturuldu"
                    };
                    return Json(msg, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    var msg = new
                    {
                        success = false,
                        message = "Sipariş oluşturulurken bir hata oluştu " + ex.Message
                    };
                    return Json(msg, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}