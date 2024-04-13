using Microsoft.AspNetCore.Mvc;
using COMP003B.Assignment3.Models;

namespace COMP003B.Assignment3.Controllers
{
    public class UsersController : Controller
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
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingUser = _users.FirstOrDefault(u => u.Id == users.Id);

                if (existingUser != null)
                {
                    existingUser.Name = users.Name;
                    existingUser.Age = users.Age;
                    existingUser.EmailAddress = users.EmailAddress;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                _users.Remove(user);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
