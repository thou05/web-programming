using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using test20212v1.Models;

namespace test20212v1.Controllers
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

        public JsonResult LttLoadNav()
        {
            var nav = _db.NavItems.ToList();
            return Json(nav);
        }

        public JsonResult LttGetTop4()
        {
            //gia nho nhat
            //var products = _db.Products.OrderBy(p => p.UnitPrice).Take(4).ToList();

            //gia lon nhat
            var products = _db.Products.OrderByDescending(p => p.UnitPrice).Take(4).ToList();
            return Json(products);
        }

        public JsonResult LttSearch(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) {
                return LttGetTop4();
            }

            var data = _db.Products.Where(x => x.Name.Contains(keyword))
                        .ToList();
            return Json(data);
        }

        // GET: Customers/Create

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
