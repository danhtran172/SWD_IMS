using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Domain.Entities.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int TrainingProgramId { get; set; }

        public TrainingProgram TrainingProgram { get; set; } = null!;
        public List<TaskResult> TaskResults { get; set; } = new();
    }
}