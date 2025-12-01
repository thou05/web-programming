using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using test20213v2.Models;

namespace test20213v2.Controllers
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

        public JsonResult LttLoadTheoLoai()
        {
            var cate = _db.Categories.ToList();
            return Json(cate);
        }

        public JsonResult LttLoadSanPham()
        {
            var products = _db.Products.Where(p => p.Available && p.UnitPrice <= 1000).ToList();
            return Json(products);
        }

        public JsonResult LttLoadCate(int id)
        {
            var products = _db.Products.Where(p => p.CategoryId == id).ToList();
            return Json(products);
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_db.Categories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([Bind("Id,Name,UnitPrice,Image,Available,CategoryId,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }
    }
}
