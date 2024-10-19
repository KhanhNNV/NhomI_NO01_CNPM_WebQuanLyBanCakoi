using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Permission
{
    public int PermissionId { get; set; }

    public string? PermissionName { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
