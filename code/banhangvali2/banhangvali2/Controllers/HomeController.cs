using banhangvali2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace banhangvali2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QlbanValiContext _db;

        public HomeController(ILogger<HomeController> logger, QlbanValiContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
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

        public JsonResult LttLoadTheoLoai()
        {
            var loaisp = _db.TLoaiSps.ToList();
            return Json(loaisp);
        }

        //public JsonResult LttLoadSp()
        //{
        //    var sp = _db.TDanhMucSps.ToList();
        //    return Json(sp);
        //}

        public JsonResult LttLoadSp(int page = 1, int pageSize = 8, string? maLoai = null)
        {
            var query = _db.TDanhMucSps.AsQueryable();

            //neu int 
            //if (maLoai.HasValue)
            //{
            //    query = query.Where(x => x.MaLoai == maLoai.Value);
            //}

            //string
            if (!string.IsNullOrEmpty(maLoai))
            {
                query = query.Where(x => x.MaLoai == maLoai);
            }

            var total = query.Count();

            var sp = query
                     .OrderBy(x => x.TenSp)
                     .Skip((page - 1) * pageSize)
                     .Take(pageSize)
                     .Select(x => new {
                         MaSp = x.MaSp.Trim(),
                         TenSp = x.TenSp.Trim(),
                         GiaNhoNhat = x.GiaNhoNhat,
                         AnhDaiDien = x.AnhDaiDien.Trim(),
                         MaLoai = x.MaLoai.Trim()
                     })
                     .ToList();

            return Json(new { products = sp, total, page, pageSize });
        }
    }
}
