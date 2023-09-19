using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SignUpLogin.Data;
using SignUpLogin.Models;
using System.Diagnostics;

namespace SignUpLogin.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ApplicationDbContext _db;
        public readonly IHttpContextAccessor _context;
        public LoginController(ILogger<LoginController> logger, ApplicationDbContext db, IHttpContextAccessor context)
        {

            _logger = logger;
            _db = db;
            _context = context;
        }

        public IActionResult Index()
        {

            IEnumerable<SignUpModel> objAccountList= _db.Accounts;
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(LoginModel obj)
        {
            if (ModelState.IsValid)
            {
                var User = _db.Accounts.SingleOrDefault(u => u.Email == obj.Email && u.Password == obj.Password);
                if (User != null)
                {
                    _context.HttpContext.Session.SetString("Email", obj.Email);

                    return RedirectToAction("Index","Home",User);
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid Email or Password!");
                }
            }
            return View("Index",obj);
        }

        public IActionResult LogOut()
        {
            _context.HttpContext.Session.SetString("Email","");
            return View("Index");
        }
    }
}