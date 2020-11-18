using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPPO.Models;
using SPPO.MyDBContext;

namespace SPPO.Controllers
{
    public class CategoryController : Controller
    {
        private MyDbContext _context;
        public CategoryController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult GetAll()
        {
           // MyDbContext db = new MyDbContext();
            List<CategoryGetAllVM> a = _context.categories.Select(a => new CategoryGetAllVM
            {
                Name = a.Name,
                ID = a.Id,
                Description = a.Description
            }).ToList();

            return View(a);
        }
    }
}
