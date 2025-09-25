
using banhang.Models;

namespace banhang.Repository
{
    public interface ILoadSpRepo
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp Delete(String maloaiSp);
        TLoaiSp GetById(String maloaiSp);
        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}
