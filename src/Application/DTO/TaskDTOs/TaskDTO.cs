using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Application.DTO.TaskDTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public int TrainingProgramId { get; set; }
    }
}