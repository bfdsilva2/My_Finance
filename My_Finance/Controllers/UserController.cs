using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Finance.Models;

namespace My_Finance.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login(int? id)
        {
            if (id == 0)
            {
                this.CloseSession();
            }
            return View();
        }

        [HttpPost]
        public IActionResult ValidLogin(UserModel user)
        {
            if (user.ValidLogin())
            {
                HttpContext.Session.SetString("LoggedUserId", user.Id.ToString());
                HttpContext.Session.SetString("LoggedUserName", user.Name);
                HttpContext.Session.SetString("LoggedUserBirthDate", user.BirthDate.ToString());
                return RedirectToAction("Menu", "Home");

            }
            else
            {
                TempData["InvalidLoginMessage"] = "Password or e-mail incorrect.";
                return RedirectToAction("Login");
            }
        }

        private void CloseSession()
        {
            HttpContext.Session.Clear();
        }

        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                user.Register();
                return RedirectToAction("Success");
            }
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
