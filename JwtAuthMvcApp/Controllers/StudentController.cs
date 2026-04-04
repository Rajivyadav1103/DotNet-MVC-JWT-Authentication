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
    }
}
