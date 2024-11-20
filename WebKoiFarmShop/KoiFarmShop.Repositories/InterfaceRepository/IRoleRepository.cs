using KoiFarmShop.Repositories.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.InterfaceRepository
{
    public interface IRoleRepository
    {
        Task<List<IdentityRole<int>>> GetAllRole();
        Task<bool> DelRole(int Id);
        Task<bool> DelRole(IdentityRole<int> role);
        Task<bool> AddRole(IdentityRole<int> role);
        Task<bool> UpRole(IdentityRole<int> role);
        Task<IdentityRole<int>> GetRoleById(int Id);
    }
}
