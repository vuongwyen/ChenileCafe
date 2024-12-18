using ChenileCafe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace ChenileCafe.Controllers
{

    [Authorize(Policy = "AdminOnly")]
    public class AdminController : Controller
    {
        private readonly ChenilleDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public AdminController(ChenilleDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var users = _context.Users.OrderByDescending(x => x.Id).ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }

            User user = new User()
            {
                Name = userDto.Name,
                PhoneNumber = userDto.PhoneNumber,
                Birth = userDto.Birth,
                Email = userDto.Email,
                Password = userDto.Password,
                Roles = userDto.Roles
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }
    }
}
