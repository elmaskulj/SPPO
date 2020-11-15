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
        public IActionResult Registracija()
        {

            return View("Registracija");
        }
        public IActionResult Save(UserRegistracijaVM m)
        {
            if (ModelState.IsValid)
            {
                MyDbContext db = new MyDbContext();

                Account a = new Account();
                if (m.CompanyName is null)
                {
                    User u = new User();
                    u.FirstName = m.FirstName;
                    u.LastName = m.LastName;
                    u.BirthDate = m.BirthDate;
                    u.PhoneNumber = m.PhoneNumber;
                    u.Email = m.Email;

                    db.Add(u);
                    db.SaveChanges();

                    a = new Account();
                    a.UserID = u.Id;
                }
                else
                {
                    Company c = new Company();
                    c.Email = m.Email;
                    c.Name = m.CompanyName;
                    c.PhoneNumber = m.PhoneNumber;

                    db.Add(c);
                    db.SaveChanges();

                    a.CompanyID = c.Id;
                }
                a.UserName = m.UserName;
                a.PasswordHash = m.Password;
                db.Add(a);
                db.SaveChanges();
            }
            return View("Save");
        }
    }
}
