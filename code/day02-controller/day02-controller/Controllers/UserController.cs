using Microsoft.AspNetCore.Mvc;

namespace day02_controller.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
