using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SignUpLogin.Data;
using SignUpLogin.Models;
using System.Diagnostics;

namespace SignUpLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<LoginSignUpModel> objAccountList= _db.Accounts;
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(LoginModel obj)
        {
            if (ModelState.IsValid)
            {
                var User = _db.Accounts.FirstOrDefault(u => u.Email == obj.Email && u.Password == obj.Password);
                if (User != null)
                {
                    return RedirectToAction("Index","Dashboard",User);
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid Email or Password!");
                }
            }
            return View("Index",obj);
        }
    }
}