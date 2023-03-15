using Microsoft.AspNetCore.Mvc;

namespace My_Finance.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TransactionList()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
