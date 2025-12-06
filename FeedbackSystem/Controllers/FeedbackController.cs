using FeedbackSystem.Data;
using FeedbackSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace FeedbackSystem.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Feedback/Submit/teacherId
        public IActionResult Submit(int teacherId)
        {
            var teacher = _context.Teachers.Find(teacherId);
            return View(teacher);
        }

        // POST: Feedback/Submit
        [HttpPost]
        public IActionResult Submit(int teacherId, int rating, string comment)
        {
            int? studentId = HttpContext.Session.GetInt32("StudentId");

            if (studentId == null)
                return RedirectToAction("Login", "Student");

            Feedback f = new Feedback()
            {
                TeacherId = teacherId,
                StudentId = studentId.Value,
                Rating = rating,
                Comment = comment,
                Date = DateTime.Now
            };

            _context.Feedbacks.Add(f);
            _context.SaveChanges();

            return RedirectToAction("Success");
        }

        // GET: Feedback/Success
        public IActionResult Success()
        {
            return View();
        }
    }
}
