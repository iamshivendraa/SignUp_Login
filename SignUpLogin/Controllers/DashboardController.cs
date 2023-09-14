using Microsoft.AspNetCore.Mvc;

namespace SignUpLogin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("Dashboard");
        }
    }
}
