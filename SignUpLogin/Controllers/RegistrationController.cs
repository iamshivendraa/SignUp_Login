using Microsoft.AspNetCore.Mvc;
using SignUpLogin.Data;
using SignUpLogin.Models;

namespace SignUpLogin.Controllers
{

    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RegistrationController(ApplicationDbContext db)
        {

            _db = db;
        }

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
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(obj);

        }
    }
}
