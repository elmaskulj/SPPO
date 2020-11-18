using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPPO.EntityModels;
using SPPO.Models;
using SPPO.MyDBContext;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace SPPO.Controllers
{
    public class UserController : Controller
    {
        private MyDbContext _context;
        public UserController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Registracija()
        {

            return View("Registracija");
        }
        public IActionResult Save(UserRegistracijaVM m)
        {
            if (ModelState.IsValid)
            {
                //MyDbContext db = new MyDbContext();

                Account a = new Account();
                if (m.CompanyName is null)
                {
                    User u = new User();
                    u.FirstName = m.FirstName;
                    u.LastName = m.LastName;
                    u.BirthDate = m.BirthDate;
                    u.PhoneNumber = m.PhoneNumber;
                    u.Email = m.Email;

                    _context.Add(u);
                    _context.SaveChanges();

                    a = new Account();
                    a.UserID = u.Id;
                }
                else
                {
                    Company c = new Company();
                    c.Email = m.Email;
                    c.Name = m.CompanyName;
                    c.PhoneNumber = m.PhoneNumber;

                    _context.Add(c);
                    _context.SaveChanges();

                    a.CompanyID = c.Id;
                }
                a.UserName = m.UserName;
                a.PasswordHash = m.Password;
                _context.Add(a);
                _context.SaveChanges();
            }
            return View("Save");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserRegistracijaVM account)
        {
            //MyDbContext db = new MyDbContext();
            if (ModelState.IsValid)
            {
                var user = _context.accounts.Where(a => a.UserName == account.UserName && a.PasswordHash == account.Password).ToList();
                if (user.FirstOrDefault() != null)
                {
                    TempData["UserName"] = user.FirstOrDefault().UserName;
                    return Redirect("Prikazi");
                }
                else
                {
                    ModelState.AddModelError("", "Neuspješan login, pokušajte ponovo!.");
                }
            }
            return View(account);
        }
        public IActionResult Prikazi()
        {
            return View();
        }
    }
}
