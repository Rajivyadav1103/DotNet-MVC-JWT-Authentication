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

        [HttpPost]
        public JsonResult AddStudent(Student obj)
        {
            // Save to database
            _context.Students.Add(obj);
            _context.SaveChanges();

            // Return JSON response
            return Json(new { success = true, message = "Student saved successfully" });
        }

    }
}
