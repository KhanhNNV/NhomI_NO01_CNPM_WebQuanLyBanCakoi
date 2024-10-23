using KoiFarmShop.Repositories.Entities;
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
        Boolean DelRole(int RoleId);
        Boolean DelRole(Role RoleName);
        Boolean AddRole(Role RoleName);
        Boolean UpRole(Role role);
        Task<Role> GetRoleById(int RoleId);
    }
}
