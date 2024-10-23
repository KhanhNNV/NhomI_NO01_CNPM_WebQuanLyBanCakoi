﻿using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.InterfaceRepository
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRole();
        Boolean DelRole(int Id);
        Boolean DelRole(Role role);
        Boolean AddRole(Role role);
        Boolean UpRole(Role role);
        Task<Role> GetRoleById(int Id);
    }
}
