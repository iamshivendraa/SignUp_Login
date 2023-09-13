using Microsoft.AspNetCore.Mvc;
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
            IEnumerable<LoginSignUpModel> objAccountList = _db.Accounts;
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        //GET
        public IActionResult SignUp()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(LoginSignUpModel obj)
        {
            {
                if (ModelState.IsValid)
                {
                     _db.Accounts.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}