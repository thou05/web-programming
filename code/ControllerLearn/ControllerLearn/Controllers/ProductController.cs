using Microsoft.AspNetCore.Mvc;

namespace ControllerLearn.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View("views/product/chi-tiet.cshtml");
        }
    }
}
