using FeedbackSystem.Data;
using FeedbackSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FeedbackSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Student/Login
        [HttpPost]
        public IActionResult Login(Student student)
        {
            var user = _context.Students
                .FirstOrDefault(s => s.Email == student.Email && s.Password == student.Password);

            if (user == null)
            {
                ViewBag.Error = "Invalid Login!";
                return View();
            }

            // Store student ID in session
            HttpContext.Session.SetInt32("StudentId", user.StudentId);

            return RedirectToAction("Dashboard");
        }

        // GET: Student/Dashboard
        public IActionResult Dashboard()
        {
            var teachers = _context.Teachers.ToList();
            return View(teachers);
        }
    }
}
