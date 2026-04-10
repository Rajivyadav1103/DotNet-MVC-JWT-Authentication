using JwtAuthMvcApp.DAO;
using Microsoft.AspNetCore.Mvc;
using JwtAuthMvcApp.Models;

namespace JwtAuthMvcApp.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context) {
           _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // ===== SAVE =====
        [HttpPost]
        public JsonResult AddStudent([FromBody] Student obj)
        {
            if (obj == null)
            {
                return Json(new { success = false, message = "Invalid data" });
            }

            obj.IsActive = true; // ✅ default
            obj.Createddate = DateTime.Now; // ✅ auto date

            _context.Students.Add(obj);
            _context.SaveChanges();

            return Json(new { success = true, message = "Student saved successfully" });
        }

        // ===== LOAD =====
        [HttpGet]
        public JsonResult GetStudents()
        {
            var data = _context.Students
                               .Where(x => x.IsActive == true) // ✅ only active
                               .ToList();

            return Json(data);
        }

        [HttpPost]
        public JsonResult UpdateStudent([FromBody] Student model)
        {
            if (model == null)
            {
                return Json(new { success = false, message = "Invalid data" });
            }

            var data = _context.Students.Find(model.StudentId); // ✅ fix

            if (data != null)
            {
                data.Name = model.Name;
                data.Age = model.Age;
                data.course = model.course;
                data.Email = model.Email;
                data.PhoneNumber = model.PhoneNumber;

                _context.SaveChanges(); // ✅ fix

                return Json(new { success = true, message = "Updated successfully" });
            }

            return Json(new { success = false, message = "Student not found" });
        }


        [HttpDelete]
        public JsonResult DeleteStudent(int id)
        {
            var data = _context.Students.Find(id); // ✅ use _context

            if (data != null)
            {
                _context.Students.Remove(data);   // ✅ fix
                _context.SaveChanges();           // ✅ fix

                return Json(new { success = true, message = "Deleted successfully" });
            }

            return Json(new { success = false, message = "Student not found" });
        }



    }
}
