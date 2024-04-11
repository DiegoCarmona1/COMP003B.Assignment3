using Microsoft.AspNetCore.Mvc;
using COMP003B.Assignment3.Models;

namespace COMP003B.Assignment3.Controllers
{
    public class RegisterUser : Controller
    {
        private static List<User> _users = new List<User>();
        public IActionResult Index()
        {
            return View(_users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User users)
        {
            if (ModelState.IsValid)
            {
                if (!_users.Any(u => u.Id == users.Id))
                {
                    _users.Add(users);
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User users)
        {
            if (id != User.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingUser = _users.FirstOrDefault(u => u.Id == users.Id);

                if (existingUser != null)
                {
                    existingUser.Name = users.Name;
                    existingUser.Email = users.Email;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {

        }
    }
}
