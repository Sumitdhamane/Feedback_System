using System;
using System.ComponentModel.DataAnnotations;

namespace FeedbackSystem.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }

        public int StudentId { get; set; }
        public int TeacherId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
    }
}
