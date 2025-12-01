using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using pretest3.Models;
using System.Diagnostics;

namespace pretest3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QlhangHoaContext _context;

        public HomeController(ILogger<HomeController> logger, QlhangHoaContext context)
        {
            _logger = logger;
            _context = context;
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

        public JsonResult LttLoadLoaiHang()
        {
            var loaihang = _context.LoaiHangs.ToList();
            return Json(loaihang);
        }

        public JsonResult LttHangHoaByLoai()
        {
            var hanghoa = _context.HangHoas.Where(x => x.Gia >= 100).ToList();
            return Json(hanghoa);
        }

        public JsonResult LttSearch(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                var all = _context.HangHoas.ToList();
                return Json(all);
            }

            var data = _context.HangHoas
                        .Where(x => x.TenHang.Contains(keyword))
                        .ToList();

            return Json(data);
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("MaHang,MaLoai,TenHang,Gia,Anh")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }
    }

}
