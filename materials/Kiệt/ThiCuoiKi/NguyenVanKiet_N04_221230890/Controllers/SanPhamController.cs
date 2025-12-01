using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NguyenVanKiet_N04_221230890.Models;
using NguyenVanKiet_N04_221230890.ViewModels;

namespace NguyenVanKiet_N04_221230890.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        QlbanGiayContext db = new QlbanGiayContext();
        [HttpGet]
        public IEnumerable<SanPhamTheoPhanLoaiPhu> GetAllPhanLoaiPhu()
        {
            var sanpham = (from td in db.SanPhams
                           select new SanPhamTheoPhanLoaiPhu
                           {
                               MaSanPham = td.MaSanPham,
                               TenSanPham = td.TenSanPham,
                               DonGiaBanNhoNhat = td.DonGiaBanNhoNhat,
                               AnhDaiDien = td.AnhDaiDien,
                               MaPhanLoaiPhu = td.MaPhanLoaiPhu,
                           }).ToList();
            return sanpham;
        }
        [HttpGet("{maphanloaiphu}")]
        public IEnumerable<SanPhamTheoPhanLoaiPhu> GetAllSanPhamByPhanLoaiPhu(string maphanloaiphu)
        {
            var sanpham = (from td in db.SanPhams
                           where td.MaPhanLoaiPhu == maphanloaiphu
                           select new SanPhamTheoPhanLoaiPhu
                           {
                               MaSanPham = td.MaSanPham,
                               TenSanPham = td.TenSanPham,
                               DonGiaBanNhoNhat = td.DonGiaBanNhoNhat,
                               AnhDaiDien = td.AnhDaiDien,
                               MaPhanLoaiPhu = td.MaPhanLoaiPhu,
                           }).ToList();
            return sanpham;
        }
    }
}
