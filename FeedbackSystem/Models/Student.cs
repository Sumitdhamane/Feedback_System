using System.ComponentModel.DataAnnotations;

namespace FeedbackSystem.Models
{
    public class Student
    {

        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
