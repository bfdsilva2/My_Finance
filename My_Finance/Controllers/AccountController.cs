using Microsoft.AspNetCore.Mvc;
using My_Finance.Models;

namespace My_Finance.Controllers
{
    public class AccountController : Controller
    {
        IHttpContextAccessor HttpContextAccessor; 
        public AccountController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            AccountModel objAccount = new AccountModel(HttpContextAccessor);
            ViewBag.Accounts = objAccount.ListAccountModels();
            return View();
        }

        [HttpPost]
        public IActionResult AddAccount(AccountModel form) 
        {
            form.SetHttpContextAccessor(HttpContextAccessor);
            if (ModelState.IsValid)
            {
                form.Insert();
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddAccount()
        {
            return View();
        }
        public IActionResult DeleteAccount(int id)
        {
            AccountModel objAccount = new AccountModel(HttpContextAccessor);
            objAccount.Delete(id);
            return RedirectToAction("index");
        }
    }
}
