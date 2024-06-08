using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SWD_IMS.Entities.Enum;

namespace SWD_IMS.src.Domain.Entities.Models
{
    public class JobPosition
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public JobStatusEnum Status { get; set; } = JobStatusEnum.deactive;

        public User HRManager { get; set; } = null!;
        public List<Application> Applications { get; set; } = new();
    }
}