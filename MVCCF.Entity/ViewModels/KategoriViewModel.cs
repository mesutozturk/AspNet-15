using MVCCF.Entity.Models;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVCCF.Entity.ViewModels
{
    public class KategoriViewModel : Temel<int>
    {
        [Required]
        [StringLength(50)]
        [Display(Name ="Kategori Adı")]
        public string KategoriAdi { get; set; }
        [Display(Name ="Açıklama")]
        public string Aciklama { get; set; }
        [Display(Name ="Üst Kategori")]
        public int? UstKategoriId { get; set; }
        public string KategoriFotoUrl { get; set; }
        public HttpPostedFileBase Dosya { get; set; }
    }
}
