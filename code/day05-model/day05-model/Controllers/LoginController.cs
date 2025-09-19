using day05_model.Models;
using Microsoft.AspNetCore.Mvc;

namespace day05_model.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                if (login.username == "admin" && login.password == "123")
                {
                    string msg = "Welcome " + login.username;
                    return Content(msg);

                    //ViewBag.message = "Login Successful";
                }
                else
                {
                    ViewBag.message = "Login Failed";
                }
            }
               
            return View();
        }
    }
}
