using Microsoft.AspNetCore.Mvc;
using SignUpLogin.Data;
using SignUpLogin.Models;
using System.Collections;

namespace SignUpLogin.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Accounts()
        {
            List<SignUpModel> accountList = _db.Accounts.ToList();
            return View(accountList);
        }
    }
}
