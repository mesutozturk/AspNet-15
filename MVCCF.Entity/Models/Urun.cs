using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCF.Entity.Models
{
    [Table("Urunler")]
    public class Urun : Temel<long>
    {
        [Required]
        [StringLength(100)]
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; } = 0;
        public decimal? EskiFiyat { get; set; }
        public int KategoriId { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual List<Dosya> Dosyalar { get; set; } = new List<Dosya>();
    }
}
