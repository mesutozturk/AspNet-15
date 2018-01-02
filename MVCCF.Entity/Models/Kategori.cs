using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCF.Entity.Models
{
    [Table("Kategoriler")]
    public class Kategori : Temel<int>
    {
        [Required]
        [StringLength(50)]
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public int? UstKategoriId { get; set; }
        public string KategoriFotoUrl { get; set; }

        [ForeignKey("UstKategoriId")]
        public virtual Kategori UstKategori { get; set; }
        public virtual List<Urun> Urunler { get; set; } = new List<Urun>();
    }
}
