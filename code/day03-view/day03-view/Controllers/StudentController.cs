using Microsoft.AspNetCore.Mvc;

namespace day03_view.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
