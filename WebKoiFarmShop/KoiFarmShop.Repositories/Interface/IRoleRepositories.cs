using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interface
{
    public interface IRoleRepositories
    {
        Task<List<Role>> GetAllRole();
        Boolean DelRole(int RoleId);
        Boolean DelRole(Role RoleName);
        Boolean AddRole(Role RoleName);
        Boolean UpRole(Role role);
        Task<Role> GetRoleById(int RoleId);
        void Add(Role role);
        void Update(Role role);
        void Delete(Role role);
        Task SaveChangesAsync();
    }
}
