using Microsoft.EntityFrameworkCore;
using FeedbackSystem.Models;

namespace FeedbackSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
