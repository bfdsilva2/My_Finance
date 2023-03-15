using Microsoft.AspNetCore.Mvc;

namespace My_Finance.Controllers
{
    public class AccountPlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
