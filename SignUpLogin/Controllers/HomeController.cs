using Microsoft.AspNetCore.Mvc;
using SignUpLogin.Data;
using SignUpLogin.Models;
using SignUpLogin.ViewModel;
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
            IEnumerable<LoginSignUpModel> objAccountList = _db.Accounts;
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var authentication = _db.Accounts.FirstOrDefault(u => u.Email == obj.Email && u.Password == obj.Password);
                if (authentication != null)
                {
                    return RedirectToAction("Index","Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email or Password!");
                }
            }
            return RedirectToAction("Index");
        }

    }
}