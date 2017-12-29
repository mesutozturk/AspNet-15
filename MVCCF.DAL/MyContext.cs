using MVCCF.Entity.Models;
using System.Data.Entity;

namespace MVCCF.DAL
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyCon")
        { }

        public virtual DbSet<Dosya> Dosyalar { get; set; }
        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
    }
}
