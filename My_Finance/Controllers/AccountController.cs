using Microsoft.AspNetCore.Mvc;

namespace My_Finance.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
