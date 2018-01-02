using MVCCF.BLL.Repository;
using MVCCF.Entity.Models;
using MVCCF.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCCF.Web.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        public async Task<ActionResult> Index()
        {
            var model = await new KategoriRepo().GetAll();
            return View(model);
        }
        public async Task<ActionResult> Ekle()
        {
            var kategoriList = await new KategoriRepo().GetAll();
            var kategoriler = new List<SelectListItem>();
            kategoriler.Add(new SelectListItem()
            {
                Text = "Üst Kategorisi Yok",
                Value = "0"
            });
            kategoriList.ForEach(x =>
            kategoriler.Add(new SelectListItem
                {
                    Text = x.KategoriAdi,
                    Value = x.Id.ToString()
                })
            );
            ViewBag.kategoriler = kategoriler;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(KategoriViewModel model)
        {
            return View();
        }
        public ActionResult Guncelle(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var guncellenecek = new KategoriRepo().GetById(id.Value);
            if (guncellenecek == null)
                return RedirectToAction("Index");
            return View(guncellenecek);
        }

    }
}