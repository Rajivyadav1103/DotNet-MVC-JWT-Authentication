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

    }
}
