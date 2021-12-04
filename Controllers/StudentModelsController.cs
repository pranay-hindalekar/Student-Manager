using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Manager.Data;
using Student_Manager.Models;

namespace Student_Manager.Controllers
{
    public class StudentModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<StudentModel> objList = _context.Student;
            return View(objList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("StudentId,StudentName,StudentEmail,StudentContact")] StudentModel detail)
        {
            
                _context.Add(detail);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if(id==null|| id==0)
            {
                return NotFound();
            }
            StudentModel stud = _context.Student.Find(id);
            if(stud==null)
            {
                return NotFound();
            }
            return View(stud);
        }

        [HttpPost]
        public IActionResult Update([Bind("StudentId,StudentName,StudentEmail,StudentContact")] StudentModel student)
        {
            if (student != null)
            {
                _context.Update(student);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            StudentModel stud = _context.Student.Find(id);
            if (stud == null)
            {
                return NotFound();
            }
            return View(stud);
        }

        [HttpPost]
        public IActionResult Delete(StudentModel stud)
        {
            if (stud != null)
            {
                _context.Remove(stud);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        //[FromRoute("SearchStudent/Sea")]
        [HttpGet]
        public IActionResult SearchStudent(String SearchString)
        {
            if(SearchString!=null)
            {
                IEnumerable<StudentModel> searchobj = _context.Student.Where(str=>
                str.StudentName.Contains(SearchString)||str.StudentEmail.Contains(SearchString));
                return View(searchobj);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
