using MVCCF.Entity.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVCCF.Entity.ViewModels
{
    public class UrunViewModel:Temel<long>
    {
        [Required]
        [StringLength(100)]
        [Display(Name ="Ürün Adı")]
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; } = 0;
        [Display(Name = "Eski Fiyat")]
        public decimal? EskiFiyat { get; set; }
        public int KategoriId { get; set; }
        public List<string> FotoUrList { get; set; } = new List<string>();
        public List<HttpPostedFileBase> Dosyalar { get; set; } = new List<HttpPostedFileBase>();
    }
}
