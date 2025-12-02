using LeThiThao_231230910.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LeThiThao_231230910.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VanTai2512V1Context _db;

        public HomeController(ILogger<HomeController> logger, VanTai2512V1Context db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var data = _db.Chuyens
                .Include(c => c.SoXeNavigation)
                .Include(c => c.MaTuyenNavigation)
                .OrderByDescending(c => c.SoXe)
                .Take(6)
                .ToList();

            return View(data);
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

        public JsonResult LoadChuyen()
        {
            var chuyen = _db.Chuyens.OrderByDescending(p => p.SoXe).Take(6).ToList();
            return Json(chuyen);
        }

        [HttpGet]
        [Route("create")]

        
        public IActionResult Create()
        {
            ViewData["MaLaiXe"] = new SelectList(_db.LaiXes, "MaLaiXe", "HoTen");
            ViewData["MaTuyen"] = new SelectList(_db.Tuyens, "MaTuyen", "TenTuyen");
            ViewData["SoXe"] = new SelectList(_db.Xes, "SoXe", "SoXe");
            return View();
        }

        //POST: Chuyens/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to.
        //For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

       [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([Bind("MaChuyen,MaTuyen,SoXe,MaLaiXe,NgayGio")] Chuyen chuyen)
        {
            if (ModelState.IsValid)
            {
                _db.Add(chuyen);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLaiXe"] = new SelectList(_db.LaiXes, "MaLaiXe", "HoTen", chuyen.MaLaiXe);
            ViewData["MaTuyen"] = new SelectList(_db.Tuyens, "MaTuyen", "TenTuyen", chuyen.MaTuyen);
            ViewData["SoXe"] = new SelectList(_db.Xes, "SoXe", "SoXe", chuyen.SoXe);
            return View(chuyen);
        }



        //public JsonResult PagingChuyen(string soXe = "", int page = 1, int pageSize = 4)
        //{
        //    var query = _db.Chuyens
        //        .Include(c => c.SoXeNavigation)
        //        .Include(c => c.MaTuyenNavigation)
        //        .AsQueryable();

        //    // 🔥 Nếu có lọc theo số xe thì áp dụng
        //    if (!string.IsNullOrEmpty(soXe))
        //    {
        //        query = query.Where(x => x.SoXe.Contains(soXe));
        //    }

        //    var total = query.Count();

        //    var data = query
        //        .OrderByDescending(c => c.SoXe)
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize)
        //        .Select(x => new
        //        {
        //            MaChuyen = x.MaChuyen,
        //            TenTuyen = x.MaTuyenNavigation.TenTuyen,
        //            BienSo = x.SoXeNavigation.SoXe,
        //            Anh = x.SoXeNavigation.Anh,
        //            Ngay = x.NgayGio.HasValue ? x.NgayGio.Value.ToString("yyyy-MM-dd") : "",
        //            Gio = x.NgayGio.HasValue ? x.NgayGio.Value.ToString("HH:mm") : ""
        //        })
        //        .ToList();

        //    return Json(new { total, data });
        //}


    }
}
