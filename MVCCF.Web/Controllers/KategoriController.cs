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
    public class KategoriController : BaseController
    {
        // GET: Kategori
        public async Task<ActionResult> Index()
        {
            var model = await new KategoriRepo().GetAll();
            return View(model);
        }
        public async Task<ActionResult> Ekle()
        {
            ViewBag.kategoriler = await KategoriSelectList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Ekle(KategoriViewModel model)
        {
            if (model == null)
                return RedirectToAction("Ekle");
            Kategori yeniKategori = new Kategori()
            {
                Aciklama = model.Aciklama,
                AktifMi = model.AktifMi,
                KategoriAdi = model.KategoriAdi,
                UstKategoriId = model.UstKategoriId == 0 ? null : model.UstKategoriId
            };
            try
            {
                await new KategoriRepo().Insert(yeniKategori);
                //dosya upload
                if (model.Dosya != null && model.Dosya.ContentType.Contains("image") && model.Dosya.ContentLength > 0)
                {
                    var dosya = model.Dosya;
                    string fileName = Path.GetFileNameWithoutExtension(dosya.FileName);
                    string extName = Path.GetExtension(dosya.FileName);
                    fileName = SiteSettings.UrlFormatConverter(fileName);
                    fileName += Guid.NewGuid().ToString().Replace("-", "");
                    var directoryPath = Server.MapPath("~/Uploads");
                    var filePath = Server.MapPath("~/Uploads/") + fileName + extName;
                    if (!Directory.Exists(directoryPath))
                        Directory.CreateDirectory(directoryPath);
                    dosya.SaveAs(filePath);
                    ResimBoyutlandir(400, 300, filePath);
                    var kat = await new KategoriRepo().GetById(yeniKategori.Id);
                    kat.KategoriFotoUrl = @"/Uploads/" + fileName + extName;
                    await new KategoriRepo().Update();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Ekle");
            }
            return RedirectToAction("Ekle");
        }
        public async Task<ActionResult> Guncelle(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var guncellenecek = await new KategoriRepo().GetById(id.Value);
            if (guncellenecek == null)
                return RedirectToAction("Index");
            ViewBag.kategoriler = await KategoriSelectList();
            var model = new KategoriViewModel()
            {
                Id = guncellenecek.Id,
                Aciklama = guncellenecek.Aciklama,
                AktifMi = guncellenecek.AktifMi,
                EklenmeTarihi = guncellenecek.EklenmeTarihi,
                KategoriAdi = guncellenecek.KategoriAdi,
                KategoriFotoUrl = guncellenecek.KategoriFotoUrl,
                UstKategoriId = guncellenecek.UstKategoriId
            };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Guncelle(KategoriViewModel model)
        {
            if (model == null)
                return RedirectToAction("Index");
            var kategori = await new KategoriRepo().GetById(model.Id);
            if (kategori == null)
                return RedirectToAction("Index");
            kategori.KategoriAdi = model.KategoriAdi;
            kategori.UstKategoriId = model.UstKategoriId == 0 ? null : model.UstKategoriId;
            kategori.Aciklama = model.Aciklama;
            if (model.Dosya != null)
            {
                var dosya = model.Dosya;
                string fileName = Path.GetFileNameWithoutExtension(dosya.FileName);
                string extName = Path.GetExtension(dosya.FileName);
                fileName = SiteSettings.UrlFormatConverter(fileName);
                fileName += Guid.NewGuid().ToString().Replace("-", "");
                var directoryPath = Server.MapPath("~/Uploads");
                var filePath = Server.MapPath("~/Uploads/") + fileName + extName;
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                dosya.SaveAs(filePath);
                ResimBoyutlandir(400, 300, filePath);
                System.IO.File.Delete(Server.MapPath(kategori.KategoriFotoUrl));
                kategori.KategoriFotoUrl = @"/Uploads/" + fileName + extName;
            }
            await new KategoriRepo().Update();
            return RedirectToAction("Index");
        }

    }
}