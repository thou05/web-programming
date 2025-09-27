using day06_annotation.Models;
using Microsoft.AspNetCore.Mvc;

namespace day06_annotation.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserManualValid()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserManualValid(User user)
        {
            string pass = user.Password;
            if(pass.Length < 7)
            {
                ViewBag.Error = "Password phai dai hon 7 ky tu";
                return View();
            }
            return Content("Helo, you nhap dung roai");
        }
        [HttpGet]
        public IActionResult UserManualValidOther()
        {
            return View();
        }

        public IActionResult UserAnnotation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserAnnotation(User user)
        {
            if(ModelState.IsValid)
            {
                return Content("haha, out");
            }
            return View();
        }


    }
}
