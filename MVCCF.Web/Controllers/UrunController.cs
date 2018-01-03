using MVCCF.BLL.Repository;
using MVCCF.BLL.Settings;
using MVCCF.Entity.Models;
using MVCCF.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCCF.Web.Controllers
{
    public class UrunController : BaseController
    {
        // GET: Urun
        public async Task<ActionResult> Index()
        {
            var model = await new UrunRepo().GetAll();
            ViewBag.kategoriler = await KategoriSelectList();
            return View(model);
        }
        public async Task<ActionResult> Ekle()
        {
            ViewBag.kategoriler = await KategoriSelectList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Ekle(UrunViewModel model)
        {
            if (model == null)
                return RedirectToAction("Ekle");
            var yeniUrun = new Urun()
            {
                AktifMi = model.AktifMi,
                Fiyat = model.Fiyat,
                KategoriId = model.KategoriId,
                UrunAdi = model.UrunAdi
            };
            try
            {
                await new UrunRepo().Insert(yeniUrun);
                if (model.Dosyalar.Any())
                {
                    foreach (var dosya in model.Dosyalar)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(dosya.FileName);
                        string extName = Path.GetExtension(dosya.FileName);
                        fileName = SiteSettings.UrlFormatConverter(fileName);
                        fileName += Guid.NewGuid().ToString().Replace("-", "");
                        var directoryPath = Server.MapPath("~/Uploads/products");
                        var filePath = Server.MapPath("~/Uploads/products/") + fileName + extName;
                        if (!Directory.Exists(directoryPath))
                            Directory.CreateDirectory(directoryPath);
                        dosya.SaveAs(filePath);
                        ResimBoyutlandir(400, 300, filePath);
                        await new DosyaRepo().Insert(new Dosya()
                        {
                            DosyaYolu = @"/Uploads/products/" + fileName + extName,
                            AktifMi = true,
                            UrunId = yeniUrun.Id,
                            Uzanti = extName.Substring(1)
                        });
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Ekle");
            }
        }
    }
}