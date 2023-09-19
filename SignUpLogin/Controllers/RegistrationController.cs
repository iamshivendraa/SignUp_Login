using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignUpLogin.Data;
using SignUpLogin.Models;

namespace SignUpLogin.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _db;
        public readonly IHttpContextAccessor _context;
        public RegistrationController(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor;
            _db = db;
        }

        public IActionResult SignUp()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(SignUpModel obj)
        {
           
            if (ModelState.IsValid)
                {
                    _db.Accounts.Add(obj);
                    _db.SaveChanges();
                    if (_context.HttpContext.Session.GetString("Email") != null &&
                        _context.HttpContext.Session.GetString("Email") != "")
                    {
                        return RedirectToAction("Accounts","Account");
                    }
                    return RedirectToAction("Index", "Login");
                }

            return View(obj);

        }
    }
}
