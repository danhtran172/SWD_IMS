using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SWD_IMS.src.Application.DTO.Task;
using SWD_IMS.src.Domain.Entities.Models;

namespace SWD_IMS.src.Application.DTO
{
    public class TrainingProgramCreateReqModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Content { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "MentorId must be a non-negative integer")]
        public int? MentorId { get; set; }

        public List<TaskDTO>? Tasks { get; set; }
    }
}