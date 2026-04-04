using Microsoft.AspNetCore.Mvc;

namespace JwtAuthMvcApp.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
