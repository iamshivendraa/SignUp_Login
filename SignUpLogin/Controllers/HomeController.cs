using Microsoft.AspNetCore.Mvc;
using SignUpLogin.Models;

namespace SignUpLogin.Controllers
{
    public class HomeController : Controller
    {
        
    public readonly IHttpContextAccessor _context;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor;
        }
        public IActionResult Index(SignUpModel obj)
        {
           if(_context.HttpContext.Session.GetString("Email")!=null &&
              _context.HttpContext.Session.GetString("Email") != "") { 
            return View("Dashboard",obj);
            } 
           return  RedirectToAction("Index", "Login");
        }

    }
}
