using Dashboard.DBcontext;
using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Controllers
{
    public class AddpageController : Controller
    {
        private readonly ApplicationDBContext _db;

        public AddpageController(ApplicationDBContext db)
        {
            _db = db;
        }


        //create action for get
        [HttpGet]
        public IActionResult Newpage(Categorymodel catmdl)
        {
            if (catmdl.Id==0)
            {
                ModelState.AddModelError("", "Select Category");

            }
            int SelectValue = catmdl.Id;

            //Categorymodel catmodel = new Categorymodel();
            //var get_cat_data = catmodel.Name.ToList();
            //Pagemodel list = new Selectlist();
            List<Categorymodel> categorylist = new List<Categorymodel>();
            categorylist = (from cat in _db.Category select cat).ToList();
            categorylist.Insert(0, new Categorymodel { Id = 0, Name = "select" });
            ViewBag.list_of_cat = categorylist;
            return View();
        }

        //create action for post
        [HttpPost]
        public IActionResult Newpage(Pagemodel pmodel)
        {
           



            if (ModelState.IsValid)
            {
                _db.Page.Add(pmodel);
                _db.SaveChanges();
                return RedirectToAction("Newpage");
            }
            return View(pmodel);
        }

        //GET - EDIT
        public IActionResult Editpage(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Page.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editpage(Pagemodel Epgmodel)
        {
            if (ModelState.IsValid)
            {
                _db.Page.Update(Epgmodel);
                _db.SaveChanges();
                return RedirectToAction("Listpage");
            }
            return View(Epgmodel);

        }
        //GET - DELETE
        public IActionResult Deletepage(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Page.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletepagepost(int? id)
        {
            var obj = _db.Page.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Page.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Listpage");


        }

        public IActionResult Listpage()
        {
            IEnumerable<Pagemodel> Ienmuobj = _db.Page;
           
            return View(Ienmuobj);
        }
    }
}
