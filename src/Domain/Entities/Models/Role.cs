using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Domain.Entities.Models
{
    public class Role
    {
        public int RoleId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public virtual List<User> UserId { get; set; } = new();
    }
}