using ChenileCafe.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChenileCafe.Controllers
{
	public class AccountController : Controller
	{
        private readonly ChenilleDbContext _context;

        public AccountController(ChenilleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == email);

            if (user == null || user.Password != password)
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }

            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Roles)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            if (user.Roles == "admin")
                return RedirectToAction("Index", "Admin");
            else if (user.Roles == "employee")
                return RedirectToAction("Index", "Employee");
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
