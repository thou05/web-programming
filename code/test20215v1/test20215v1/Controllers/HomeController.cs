using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using test20215v1.Models;

namespace test20215v1.Controllers
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

        public JsonResult LttLoadLoai()
        {
            var loai = _db.Categories.ToList();
            return Json(loai);
        }

        public JsonResult LttLoadSp()
        {
            var sp = _db.Products.Where(p => p.Available).ToList();
            return Json(sp);
        }

        public JsonResult LttLoadByCate(int id)
        {
            var products = _db.Products.Where(p => p.CategoryId == id).ToList();
            return Json(products);
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([Bind("Id,Fullname,Email,Password,RePassword")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _db.Add(customer);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
    }
}
