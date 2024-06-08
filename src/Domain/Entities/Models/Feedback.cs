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
        public Interview Interview { get; set; } = null!;
        public User Mentor { get; set; } = null!;
        public TrainingProgram TrainingProgram { get; set; } = null!;
    }
}