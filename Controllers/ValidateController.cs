using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Manager.Data;
using Student_Manager.Models;

namespace Student_Manager.Controllers
{
    public class ValidateController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ValidateController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }


        [HttpPost]
        public JsonResult EmailExists(string studentemail)
        {
            IEnumerable<StudentModel> objList = _db.Student;
            foreach(var item in objList)
            {
                if(String.Equals(studentemail,item.StudentEmail, StringComparison.OrdinalIgnoreCase))
                {
                    return Json(false);
                }
            }
            return Json(true);
        }

        
    }
}
