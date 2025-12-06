using FeedbackSystem.Data;
using FeedbackSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Linq;

namespace FeedbackSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Admin/Login
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var user = _context.Admins
                .FirstOrDefault(a => a.Username == admin.Username && a.Password == admin.Password);

            if (user == null)
            {
                ViewBag.Error = "Invalid Login!";
                return View();
            }

            HttpContext.Session.SetInt32("AdminId", user.AdminId);

            return RedirectToAction("Dashboard");
        }

        // GET: Admin/Dashboard
        public IActionResult Dashboard()
        {
            ViewBag.TotalStudents = _context.Students.Count();
            ViewBag.TotalTeachers = _context.Teachers.Count();
            ViewBag.TotalFeedbacks = _context.Feedbacks.Count();

            ViewBag.TeacherList = _context.Teachers.ToList();

            return View();
        }

        // View feedback for one teacher
        public IActionResult Report(int teacherId)
        {
            var teacher = _context.Teachers.Find(teacherId);
            var feedbacks = _context.Feedbacks
                .Where(f => f.TeacherId == teacherId)
                .Include(f => f.Student)
                .ToList();

            ViewBag.Teacher = teacher;
            return View(feedbacks);
        }

        // ===============================
        //        EXPORT PDF
        // ===============================
        public IActionResult ExportPDF(int teacherId)
        {
            var teacher = _context.Teachers.Find(teacherId);

            var feedbacks = _context.Feedbacks
                .Where(f => f.TeacherId == teacherId)
                .Include(f => f.Student)
                .ToList();

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);

                    page.Header().Text($"Feedback Report - {teacher.Name} ({teacher.Subject})")
                        .FontSize(18).Bold();

                    page.Content().Table(table =>
                    {
                        // Define columns
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(120);  // Student
                            columns.ConstantColumn(50);   // Rating
                            columns.RelativeColumn();     // Comment
                            columns.ConstantColumn(100);  // Date
                        });

                        // Header Row
                        table.Header(header =>
                        {
                            header.Cell().Text("Student");
                            header.Cell().Text("Rating");
                            header.Cell().Text("Comment");
                            header.Cell().Text("Date");
                        });

                        // Data Rows
                        foreach (var f in feedbacks)
                        {
                            table.Cell().Text(f.Student.Name);
                            table.Cell().Text(f.Rating.ToString());
                            table.Cell().Text(f.Comment ?? "-");
                            table.Cell().Text(f.Date.ToShortDateString());
                        }
                    });
                });
            });

            byte[] pdfBytes = document.GeneratePdf();

            return File(pdfBytes, "application/pdf", "FeedbackReport.pdf");
        }
    }
}
