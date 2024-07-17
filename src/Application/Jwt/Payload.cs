using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Application.Jwt
{
    public class Payload
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public Guid SessionId { get; set; }
    }
}