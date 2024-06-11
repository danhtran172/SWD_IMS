using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Domain.Entities.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int RoleId { get; set; }

        public Role Role { get; set; } = null!;
        public List<TrainingProgram> TrainingPrograms { get; set; } = new();
        public List<JobPosition> JobPositions { get; set; } = new();
    }
}