using CRUD.Data_Access;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    public class SchoolsController : Controller
    {
        private SchoolContext _db;

        public SchoolsController(SchoolContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var course = _db.Courses.ToList();
            return View(course);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Course course = new Course();
            return View(course);
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            _db.Courses.Add(course);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            Course course = _db.Courses.Find(id);
            return View(course);   
        }
    }
}
