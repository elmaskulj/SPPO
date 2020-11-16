using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SPPO.EntityModels;
using SPPO.Models;
using SPPO.MyDBContext;

namespace SPPO.Controllers
{
    public class AdvertisementController : Controller
    {
        public IActionResult AddAdv()
        {
           MyDbContext db = new MyDbContext();

            List<SelectListItem> jobs = db.jobs.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();

            AdvertisementAddAdvVM aavm = new AdvertisementAddAdvVM();
            aavm.jobs = jobs;
            
            return View(aavm);
        }
        public IActionResult SaveAdv(AdvertisementAddAdvVM m)
        {
            if (ModelState.IsValid==true)
            {
                MyDbContext db = new MyDbContext();

                Advertisement a = new Advertisement();
                a.Name = m.Name;
                a.Description = m.Description;
                a.StartDate = DateTime.Now;
                a.EndDate = m.EndDate;
                a.JobId = m.JobId;

                db.Add(a);
                db.SaveChanges();
            }
            return Redirect("/Home/Index");
        }
    }
}
