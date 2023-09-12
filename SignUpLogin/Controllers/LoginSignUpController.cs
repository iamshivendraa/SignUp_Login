using Microsoft.AspNetCore.Mvc;

namespace SignUpLogin.Controllers
{
    public class LoginSignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
