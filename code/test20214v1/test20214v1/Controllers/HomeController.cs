using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test20214v1.Models;

namespace test20214v1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OnlineShopContext _db;

        public HomeController(ILogger<HomeController> logger, OnlineShopContext db)
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

        public JsonResult LttGetNav()
        {
            var nav = _db.NavItems.ToList();
            return Json(nav);
        }

        public JsonResult LttGetTop3Products()
        {
            var products = _db.Products.OrderByDescending(p => p.UnitPrice).Take(3).ToList();
            return Json(products);
        }

        public JsonResult LttSearch(string keyword)
        {
            var products = _db.Products.Where(p => p.Name.Contains(keyword)).ToList();
            return Json(products);
        }
    }
}
