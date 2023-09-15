using Microsoft.AspNetCore.Mvc;
using SignUpLogin.Models;

namespace SignUpLogin.Controllers
{
    public class DashboardController : Controller
    {
        
        public IActionResult Index(LoginSignUpModel obj)
        {
            return View("Dashboard",obj);
        }
    }
}
