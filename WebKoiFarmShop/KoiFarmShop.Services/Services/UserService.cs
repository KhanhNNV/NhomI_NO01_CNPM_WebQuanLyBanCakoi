using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using KoiFarmShop.Repositories.Repositories;
using KoiFarmShop.Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepositories;
        public UserService(IUserRepository userRepositories)
        {
            _userRepositories = userRepositories;
        }


        public async Task<bool> AddUser(AppUser UserName)
        {
            return await _userRepositories.AddUser(UserName);
        }

        public async Task<bool> DelUser(int UserId)
        {
            return await _userRepositories.DelUser(UserId);
        }

        public async Task<bool> DelUser(AppUser UserName)
        {
            return await _userRepositories.DelUser(UserName);
        }
        public async Task<AppUser> GetUserById(int UserId)
        {
            return await _userRepositories.GetUserById(UserId);
        }

        public async Task<bool> UpUser(AppUser user)
        {
            return await _userRepositories.UpUser(user);
        }

        public async Task<List<AppUser>> GetAllUser()
        {
            return await _userRepositories.GetAllUser();
        }
        public async Task<List<string>> GetRolesForUser(int userId)
        {
            return await _userRepositories.GetRolesForUser(userId);
        }
        public async Task<bool> AddRoleToUser(int userId, string roleName)
        {
            return await _userRepositories.AddRoleToUser(userId, roleName);
        }
    }
}
