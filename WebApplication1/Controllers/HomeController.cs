using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string userName = HttpContext.Session.GetString("UserFullName");
            ViewBag.UserName = userName;
            return View();
        }
    }
}
