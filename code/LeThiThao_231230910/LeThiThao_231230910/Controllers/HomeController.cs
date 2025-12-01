using System.Diagnostics;
using LeThiThao_231230910.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeThiThao_231230910.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QlhangHoaContext db = new QlhangHoaContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var hanghoa = db.HangHoas.Where(h => h.Gia >= 100).ToList();
            return View(hanghoa);

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

        public IActionResult GetProductsByLoai(int maLoai)
        {
            var products = db.HangHoas.Where(h => h.MaLoai == maLoai && h.Gia >= 100).ToList();
            return PartialView("LeThiThao_ProductList", products);
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(HangHoa hangHoa)
        {
            //Kiểm tra xem dữ liệu có thỏa mãn các điều kiện Validation ở Phần 1 không
            if (ModelState.IsValid)
            {
                db.HangHoas.Add(hangHoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Nếu lỗi (ví dụ nhập giá 50), load lại danh sách loại hàng để hiện lại form
            ViewBag.MaLoai = new SelectList(db.LoaiHangs, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }


    }
}
