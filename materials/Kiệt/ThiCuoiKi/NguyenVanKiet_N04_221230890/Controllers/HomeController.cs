using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NguyenVanKiet_N04_221230890.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NguyenVanKiet_N04_221230890.Controllers
{
    public class HomeController : Controller
    {
        QlbanGiayContext db = new QlbanGiayContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var listSanpham = db.SanPhams.ToList();
            return View(listSanpham);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ChiTietSanPham(string id)
        {
            var sanPham = db.SanPhams
                .Include(x => x.MaPhanLoaiNavigation)
                .Include(x => x.MaPhanLoaiPhuNavigation)
                .FirstOrDefault(x => x.MaSanPham == id);
            
            if (sanPham == null)
                return NotFound();
            
            ViewBag.PhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "PhanLoaiChinh");
            ViewBag.PhanLoaiPhu = new SelectList(db.PhanLoaiPhus, "MaPhanLoaiPhu", "TenPhanLoaiPhu");
            
            return View(sanPham);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            try
            {
                var sanPham = db.SanPhams.Find(id);
                if (sanPham == null)
                {
                    return NotFound();
                }

                db.SanPhams.Remove(sanPham);
                db.SaveChanges();
                TempData["ThongBao"] = "Đã xóa sản phẩm thành công!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Không thể xóa sản phẩm này! " + ex.Message;
                return RedirectToAction("ChiTietSanPham", new { id = id });
            }
        }
    }
}
