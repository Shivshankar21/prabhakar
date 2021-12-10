using Dashboard.DBcontext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Models;
namespace Dashboard.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult Newcategory()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Newcategory(Categorymodel Cmodel)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(Cmodel);
                _db.SaveChanges(); 
                return RedirectToAction("Newcategory");
            }
            return View(Cmodel);

        }
        
        public IActionResult Editcategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editcategory(Categorymodel Ecatmodel)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(Ecatmodel);
                _db.SaveChanges();
                return RedirectToAction("Listcategory");
            }
            return View(Ecatmodel);

        }
        
        public IActionResult Deletecategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletecategorypost(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Listcategory");


        }

    

public IActionResult Listcategory()
        {
            IEnumerable<Categorymodel> Ienmuobj = _db.Category;
            return View(Ienmuobj);
        }
    }
}


