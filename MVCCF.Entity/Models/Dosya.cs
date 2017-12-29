using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCF.Entity.Models
{
    [Table("Dosyalar")]
    public class Dosya : Temel<long>
    {
        public string DosyaYolu { get; set; }
        public string Uzanti { get; set; }
        public long? UrunId { get; set; }
        public int? KategoriId { get; set; }

        [ForeignKey("UrunId")]
        public virtual Urun Urun { get; set; }
        [ForeignKey("KategoriId")]
        public virtual Kategori Kategori { get; set; }
    }
}
