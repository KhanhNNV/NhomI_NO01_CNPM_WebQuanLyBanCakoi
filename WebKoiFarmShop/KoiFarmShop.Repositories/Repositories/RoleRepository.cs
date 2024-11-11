using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly KoiFarmShopDbContext _dbContext;
        public RoleRepository(KoiFarmShopDbContext dbContext, RoleManager<IdentityRole<int>> roleManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
        }
        public async Task<bool> AddRole(IdentityRole<int> role)
        {
            try
            {
                await _roleManager.CreateAsync(role);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
        public async Task<bool> DelRole(int id)
        {
            try
            {
                var objDel = await _roleManager.Roles.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
                if (objDel != null)
                {
                    await _roleManager.DeleteAsync(objDel);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DelRole(IdentityRole<int> role)
        {
            try
            {
                await _roleManager.DeleteAsync(role);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<IdentityRole<int>>> GetAllRole()
        {

            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IdentityRole<int>> GetRoleById(int id)
        {
            return await _roleManager.Roles.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
        }
        public async Task<bool> UpRole(IdentityRole<int> role)
        {
            try
            {
                await _roleManager.UpdateAsync(role);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}

