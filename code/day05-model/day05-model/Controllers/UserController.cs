using day05_model.Models;
using Microsoft.AspNetCore.Mvc;

namespace day05_model.Controllers
{
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {
            var users = new List<User>();
            var user1 = new User();
            user1.name = "Mark Smith";
            user1.address = "Park Street";
            user1.email = "Mark@mvcexample.com";
            var user2 = new User();
            user2.name = "John Parker";
            user2.address = "New Park";
            user2.email = "John@mvcexample.com";
            var user3 = new User();
            user3.name = "Steave Edward ";
            user3.address = "Melbourne Street";
            user3.email = "steave@mvcexample.com";
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);

            return View(users);
        }

        public IActionResult Index1()
        {
            var user = new User();
            user.id = 1;
            user.name = "John Doe";
            user.address = "123 Main St, Anytown, USA";
            user.email = "john@email.com";
            ViewBag.user = user;
            return View();
        }


        public IActionResult Index2()
        {
            var users = new List<User>();
            var user1 = new User();
            user1.name = "Mark Smith";
            user1.address = "Park Street";
            user1.email = "Mark@mvcexample.com";
            var user2 = new User();
            user2.name = "John Parker";
            user2.address = "New Park";
            user2.email = "John@mvcexample.com";
            var user3 = new User();
            user3.name = "Steave Edward ";
            user3.address = "Melbourne Street";
            user3.email = "steave@mvcexample.com";
            users.Add(user1); 
            users.Add(user2);
            users.Add(user3);
            ViewBag.user = users; 
            return View();
        }

        public IActionResult Index3()
        {
            var user = new User();
            user.name = "John Smith";
            user.address = "Park Street";
            user.email = "john@mvcexample.com";
            return View(user);
        }

        public IActionResult Index4()
        {
            var user = new List<User>();
            var user1 = new User();
            user1.name = "Mark Smith";
            user1.address = "Park Street";
            user1.email = "Mark@mvcexample.com";
            var user2 = new User();
            user2.name = "John Parker";
            user2.address = "New Park";
            user2.email = "John@mvcexample.com";
            var user3 = new User();
            user3.name = "Steave Edward ";
            user3.address = "Melbourn Street";
            user3.email = "steave@mvcexample.com";
            user.Add(user1);
            user.Add(user2);
            user.Add(user3);
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

    }
}
