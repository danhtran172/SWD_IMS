using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SWD_IMS.src.Application.DTO.TaskDTOs;

namespace SWD_IMS.src.Application.DTO.TrainingProgramDTOs
{
    public class TrainingProgramCreateDTO
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Content { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "MentorId must be a non-negative integer")]
        public int? MentorId { get; set; }

        public List<TaskDTO>? Tasks { get; set; }
        public DateOnly? StartDate { get; set; }
        public int? Duration { get; set; }
    }
}