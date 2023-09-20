using Microsoft.AspNetCore.Mvc;
using SignUpLogin.Data;
using SignUpLogin.Models;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

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

        public IActionResult Update(int? id) 
        {
            
            if(id == null || id==0)
            {
                return NotFound();
            }
            SignUpModel accountsFromDb = _db.Accounts.Find(id);
            if(accountsFromDb == null) 
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(SignUpModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Accounts.Update(obj);
                _db.SaveChanges();
                return View();
            }
            return View("Accounts",obj);
        }
    }
}
