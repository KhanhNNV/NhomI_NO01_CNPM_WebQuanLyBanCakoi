﻿using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.InterfaceService
{
    public interface IPermissionService
    {
        Task<List<Permission>> GetAllPermission();
        Boolean DeletePermission(int id);
        Boolean DeletePermission(Permission permission);
        Boolean UpdatePermission(Permission permission);
        Boolean AddPermission(Permission permission);
        Task<Permission> GetPermissionById(int id);
    }
}