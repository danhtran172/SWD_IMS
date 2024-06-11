using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Domain.Entities.Models
{
    public class WorkResult
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Percentage { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int TrainingProgramId { get; set; }
        
        public TrainingProgram TrainingProgram { get; set; } = null!;
    }
}