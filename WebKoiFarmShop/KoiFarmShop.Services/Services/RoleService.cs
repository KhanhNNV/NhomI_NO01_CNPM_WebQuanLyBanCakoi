using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using KoiFarmShop.Services.InterfaceService;
using Microsoft.AspNetCore.Identity;
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

        public async Task<bool> AddRole(IdentityRole<int> RoleName)
        {
            return await _repositories.AddRole(RoleName);

        }
        public async Task<bool> DelRole(int RoleId)
        {
            return await _repositories.DelRole(RoleId);
        }

        public async Task<bool> DelRole(IdentityRole<int> RoleName)
        {
            return await  _repositories.DelRole(RoleName);
        }

        public async Task<IdentityRole<int>> GetRoleById(int roleId)
        {
            return await _repositories.GetRoleById(roleId);
        }

        public async Task<List<IdentityRole<int>>> GetAllRole()
        {
            return await _repositories.GetAllRole();
        }
        public async Task<bool> UpRole(IdentityRole<int> role)
        {
            return await _repositories.UpRole(role);
        }

    }
}

