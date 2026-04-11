using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AuthController : Controller
{
    private readonly IConfiguration _config;

    public AuthController(IConfiguration config)
    {
        _config = config;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public JsonResult LoginUser([FromBody] LoginModel model)
    {
        if (model.Username == "admin" && model.Password == "123")
        {
            var token = GenerateToken(model.Username);
            return Json(new { success = true, token = token });
        }

        return Json(new { success = false, message = "Invalid login" });
    }

    private string GenerateToken(string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: signIn);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}