using Microsoft.AspNetCore.Mvc;

namespace day02_controller.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Product Page";
            ViewBag.Age = 18;
            TempData["Email"] = "thaole@utc.edu.vn";
            return RedirectToAction("Sample3");
        }

        public IActionResult Sample()
        {
            return View();
        }
        public IActionResult Sample2()
        {
            return View("Index");
        }
        public IActionResult Sample3()
        {
            return RedirectToAction("Index","User");
        }
    }
}
