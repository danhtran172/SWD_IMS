using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SWD_IMS.Entities.Enum;

namespace SWD_IMS.src.Domain.Entities.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Resume { get; set; } = null!;
        public string? CoverLetter { get; set; }
        public string AppliedAt { get; set; } = null!;
        public ApplicationStatusEnum Status { get; set; } = ApplicationStatusEnum.Pending;

        public JobPosition JobPosition { get; set; } = null!;
        public List<Interview> Interviews { get; set; } = new();
    }
}