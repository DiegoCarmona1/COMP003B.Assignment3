using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment3.Controllers
{
    public class RegisterUser : Controller
    {
        private static List<Users> _users = new List<Users>();
        public IActionResult Index()
        {
            return View(_users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


    }
}
