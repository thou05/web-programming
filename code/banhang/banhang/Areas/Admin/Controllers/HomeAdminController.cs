using Azure;
using banhang.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace banhang.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("danhmucsp")]
        public IActionResult DanhMucSP(int? page)
        { 
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listsp = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(listsp, pageNumber, pageSize);
            return View(lst);
        }

        [Route("ThemSPMoi")]
        [HttpGet]
        public IActionResult ThemSPMoi()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            return View();
        }

        [Route("ThemSPMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSPMoi(TDanhMucSp sp)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sp);
                db.SaveChanges();
                return RedirectToAction("DanhMucSP");   
            }
            return View(sp);
        }


        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(string maSanPham)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            var sanPham = db.TDanhMucSps.Find(maSanPham);
            return View(sanPham);
        }

        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucSp sp)
        {
            if (ModelState.IsValid)
            {
                //db.Update(sp);
                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSP", "HomeAdmin");
            }
            return View(sp);
        }

        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string maSanPham)
        {
            TempData["Message"] = "";
            var chiTietSP = db.TChiTietSanPhams.Where(x=>x.MaSp == maSanPham).ToList();
            if(chiTietSP.Count() > 0)
            {
                TempData["Message"] = "Không thể xóa sản phẩm này vì đã có trong chi tiết đơn hàng.";
                return RedirectToAction("DanhMucSP", "HomeAdmin");
            }
            var anhSP = db.TAnhSps.Where(x => x.MaSp == maSanPham);
            if (anhSP.Any()) db.RemoveRange(anhSP);
            db.Remove(db.TDanhMucSps.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Xóa sản phẩm thành công.";
            return RedirectToAction("DanhMucSP", "HomeAdmin");
           
        }

    }
    
}
