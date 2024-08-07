using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Domain.Entities.Models
{
    public class Intern
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? University { get; set; }
        public string? Major { get; set; }
        public string? Experience { get; set; }

        public List<Feedback> Feedbacks { get; set; } = new();
        public List<TrainingProgramIntern> TrainingProgramInterns { get; set; } = new();
        public List<TaskIntern> TaskInterns { get; set; } = new();
    }
    public class InternList
    {
        public List<Intern> Interns { get; set; } = new List<Intern>();
        public int TotalCount { get; set; }
    }
}