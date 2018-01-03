using MVCCF.Entity.Models;
using System.Data.Entity;

namespace MVCCF.DAL
{
    public class MyContext : DbContext
    {
        public MyContext()
#if (DEBUG)
            : base("name=MyCon")
        { }
#else
            :base("name=WebCon")
        { }
#endif

        public virtual DbSet<Dosya> Dosyalar { get; set; }
        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
    }
}
