using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Domain.Entities.Models
{
    public class TrainingProgram
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int MentorId { get; set; }
        public DateOnly? StartDate { get; set; }
        public int? Duration { get; set; } //days

        public User Mentor { get; set; } = null!;
        public List<TrainingProgramIntern> TrainingProgramInterns { get; set; } = new();
        public List<Task> Tasks { get; set; } = new();
        public List<Feedback> Feedbacks { get; set; } = new();
    }
}