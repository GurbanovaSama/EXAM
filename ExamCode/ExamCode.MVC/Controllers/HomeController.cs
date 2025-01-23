using Microsoft.AspNetCore.Mvc;

namespace ExamCode.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
