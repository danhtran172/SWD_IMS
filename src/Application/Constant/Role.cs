using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using SWD_IMS.src.Domain.Entities.Models;

namespace SWD_IMS.src.Application.Constant
{
    public class RoleConst
    {
        public const string ADMIN = "Admin";
        public const int ADMIN_ID = 1;
        public const string MENTOR = "Mentor";
        public const int MENTOR_ID = 2;
        public const string HRMANAGER = "HRManager";
        public const int HRMANAGER_ID = 3;
        public const string INTERSHIPCOORDINATOR = "IntershipCoordinator";
        public const int INTERSHIPCOORDINATOR_ID = 4;
        public const string MEMBER = "Member";
        public const int MEMBER_ID = 6;
        public Dictionary<string, int> RoleId = new()
        {
            {MEMBER, MEMBER_ID},
            {ADMIN, ADMIN_ID},
            {MENTOR, MENTOR_ID},
            {HRMANAGER, HRMANAGER_ID},
            {INTERSHIPCOORDINATOR, INTERSHIPCOORDINATOR_ID}
        };
        public static int GetRoleId(string roleName)
        {
            return new RoleConst().RoleId[roleName];
        }
    }
}