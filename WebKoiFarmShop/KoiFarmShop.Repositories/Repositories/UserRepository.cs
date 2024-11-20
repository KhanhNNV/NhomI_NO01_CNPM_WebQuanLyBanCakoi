using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public UserRepository(UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> AddUser(AppUser user)
        {
            try
            {
                await _userManager.CreateAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
        public async Task<bool> DelUser(AppUser user)
        {
            try
            {
                await _userManager.DeleteAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DelUser(int id)
        {
            try
            {
                var objDel = await _userManager.Users.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (objDel != null)
                {
                    await _userManager.DeleteAsync(objDel);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<AppUser>> GetAllUser()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }

        public async Task<AppUser> GetUserById(int id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<string>> GetRolesForUser(int userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return roles.ToList();
            }
            return new List<string>();
        }

        public async Task<bool> UpUser(AppUser user)
        {
            try
            {
                await _userManager.UpdateAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> AddRoleToUser(int userId, string roleName)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                if (user == null)
                {
                    return false; // User không tồn tại
                }

                // Kiểm tra vai trò đã tồn tại chưa
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    return false; // Vai trò không tồn tại
                }

                // Thêm vai trò vào người dùng
                var result = await _userManager.AddToRoleAsync(user, roleName);
                return result.Succeeded;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}