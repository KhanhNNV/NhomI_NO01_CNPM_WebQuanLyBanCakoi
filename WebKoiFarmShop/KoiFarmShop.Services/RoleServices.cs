using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interface;
using KoiFarmShop.Services.Interface;

namespace KoiFarmShop.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepositories _repositories;
        public object RoleId;

        public RoleServices(IRoleRepositories repositories)
        {
            _repositories = repositories;
        }

        public bool AddRole(Role RoleName)
        {
            return _repositories.AddRole(RoleName);

        }

        public async Task AddRoleAsync(Role role)
        {
            _repositories.Add(role);
            await _repositories.SaveChangesAsync();
        }

        public Task AddRoleAsync(RoleServices role)
        {
            throw new NotImplementedException();
        }

        public async Task AddRoles(Role role)
        {
            _repositories.Add(role);
            await _repositories.SaveChangesAsync();
        }

        public async Task DeleteRole(Role role)
        {
            _repositories.Delete(role);
            await _repositories.SaveChangesAsync();
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

        public Task<List<Role>> Role()
        {
            return _repositories.GetAllRole();
        }

        public bool RoleExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _repositories.SaveChangesAsync();
        }

        public async Task UpdateRole(Role role)
        {
            _repositories.Update(role);
            await _repositories.SaveChangesAsync();
        }

        public Task UpdateRoleAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public bool UpRole(Role role)
        {
            return _repositories.UpRole(role);
        }

    }
}

