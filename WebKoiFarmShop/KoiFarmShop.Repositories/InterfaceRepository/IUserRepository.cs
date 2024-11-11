using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.InterfaceRepository
{
    public interface IUserRepository
    {
        Task<List<AppUser>> GetAllUser();
        Task<bool> DelUser(int Id);
        Task<bool> DelUser(AppUser user);
        Task<bool> AddUser(AppUser user);
        Task<bool> UpUser(AppUser user);
        Task<AppUser> GetUserById(int Id);
        Task<List<string>> GetRolesForUser(int userId);
        Task<bool> AddRoleToUser(int userId, string roleName);

    }
}
