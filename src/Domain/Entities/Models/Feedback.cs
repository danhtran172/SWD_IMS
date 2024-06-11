using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Domain.Entities.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int InternId { get; set; }
        public int TrainingProgramId { get; set; }
        public Intern Intern { get; set; } = new();
        public TrainingProgram TrainingProgram { get; set; } = new();
    }
}