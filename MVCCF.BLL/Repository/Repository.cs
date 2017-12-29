using MVCCF.Entity.Models;

namespace MVCCF.BLL.Repository
{
    public class UrunRepo : RepositoryBase<Urun, long> { }
    public class KategoriRepo : RepositoryBase<Kategori, int> { }
    public class DosyaRepo : RepositoryBase<Dosya, long> { }
}
