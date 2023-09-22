using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List <SignUpModel> accountList= _db.Accounts.ToList();
            return View(accountList);
        }

        public IActionResult _Update(int? id) 
        {
            
            if(id == null || id == 0)
            {
                return NotFound();
            }
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            SignUpModel accountsFromDb = _db.Accounts.Find(id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (accountsFromDb == null) 
            {
                return NotFound();
            }
            return View(accountsFromDb);
        }
        [HttpPost]
        public IActionResult _Update(SignUpModel obj)
        {
            List<SignUpModel> accountList = _db.Accounts.ToList();
            if (ModelState.IsValid)
            {
                SignUpModel signUpModel = _db.Accounts.Find(obj.Id);
                if (signUpModel != null)
                {
                    signUpModel.FirstName = obj.FirstName;
                    signUpModel.LastName = obj.LastName;
                    signUpModel.Email = obj.Email;
                    signUpModel.Password = obj.Password;
                    signUpModel.ConfirmPassword = obj.ConfirmPassword;
                    signUpModel.Gender = obj.Gender;
                    signUpModel.Music = obj.Music;
                    signUpModel.Sports = obj.Sports;
                    signUpModel.Travel = obj.Travel;
                    signUpModel.Movies = obj.Movies;
                    signUpModel.Age = obj.Age;
                    signUpModel.Income = obj.Income;
                    signUpModel.sourceOfIncome = obj.sourceOfIncome;
                    signUpModel.Bio = obj.Bio;
                }
                    _db.Accounts.Update(signUpModel);
                    _db.SaveChanges();
                    TempData["success"] = "Account Updated Successfully!";
                    return RedirectToAction("Accounts",accountList);
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            SignUpModel accountsFromDb = _db.Accounts.Find(id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (accountsFromDb == null)
            {
                return NotFound();
            }
            return View(accountsFromDb);
        }

        [HttpPost]
        public IActionResult Delete(SignUpModel obj)
        {
            List<SignUpModel> accountList = _db.Accounts.ToList();
            var entityToDelete = _db.Accounts.Find(@obj.Id);
            if (entityToDelete!= null)
            {
                entityToDelete.IsDeleted = true;
                _db.SaveChanges();
                 return RedirectToAction("Accounts",entityToDelete);
            }
            return View();
        }
    }
}
