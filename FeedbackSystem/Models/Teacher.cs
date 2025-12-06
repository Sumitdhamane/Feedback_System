using System.ComponentModel.DataAnnotations;

namespace FeedbackSystem.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Subject { get; set; }
    }
}
