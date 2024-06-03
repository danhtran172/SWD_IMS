using System;
using System.Collections.Generic;

namespace SWD_IMS.Entities.Models;

public partial class RolePermission
{
    public int RolePermissonId { get; set; }

    public int? RoleId { get; set; }

    public int? PermissionId { get; set; }

    public virtual Permission? Permission { get; set; }

    public virtual Role? Role { get; set; }
}
