using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using KoiFarmShop.Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repositories;
       
        public RoleService(IRoleRepository repositories)
        {
            _repositories = repositories;
        }

        public bool AddRole(Role RoleName)
        {
            return _repositories.AddRole(RoleName);

        }
        public bool DelRole(int RoleId)
        {
            return _repositories.DelRole(RoleId);
        }

        public bool DelRole(Role RoleName)
        {
            return _repositories.DelRole(RoleName);
        }

        public async Task<Role> GetRoleById(int roleId)
        {
            return await _repositories.GetRoleById(roleId);
        }

        public Task<List<Role>> GetAllRole()
        {
            return _repositories.GetAllRole();
        }
        public bool UpRole(Role role)
        {
            return _repositories.UpRole(role);
        }

    }
}
}
