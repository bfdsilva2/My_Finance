using Microsoft.AspNetCore.Mvc;
using My_Finance.Models;

namespace My_Finance.Controllers
{
    public class AccountPlanController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;
        public AccountPlanController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            AccountPlanModel objAccountPlan = new AccountPlanModel(HttpContextAccessor);
            ViewBag.ListAccountPlans = objAccountPlan.ListAccountPlans();
            return View();
        }

        [HttpPost]
        public IActionResult AddAccountPlan(AccountPlanModel form)
        {
            form.SetHttpContextAccessor(HttpContextAccessor);
            if (ModelState.IsValid)
            {
                if (form.Id > 0) {
                    form.Update();                    
                }
                else
                {
                    form.Insert();
                }
                
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddAccountPlan(int? id)
        {
            if (id != null && id > 0) 
            {
                AccountPlanModel objAccountPlan = new AccountPlanModel(HttpContextAccessor);
                ViewBag.Register = objAccountPlan.LoadAccountPlan(id.Value);
            }
            return View();
        }
        public IActionResult DeleteAccountPlan(int id)
        {
            AccountPlanModel objAccountPlan = new AccountPlanModel(HttpContextAccessor);
            objAccountPlan.Delete(id);
            return RedirectToAction("index");
        }
    }
}
