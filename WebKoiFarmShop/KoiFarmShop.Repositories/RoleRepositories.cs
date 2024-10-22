using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiFarmShop.Repositories
{
    public class RoleRepositories : IRoleRepositories
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public RoleRepositories(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Role role)
        {
            _dbContext.Roles.Add(role);
        }

        public bool AddRole(Role RoleName)
        {
            try
            {
                _dbContext.Roles.Add(RoleName);
                _dbContext.SaveChanges();
                return true;
            }catch (Exception ex)
            {            
                throw new NotImplementedException();
            }
        }

        public void Delete(Role role)
        {
            _dbContext.Roles.Remove(role);
        }

        public bool DelRole(int RoleId)
        {
            try
            {
                var objDel = _dbContext.Roles.Where(p => p.RoleId.Equals(RoleId)).FirstOrDefault();
                if(objDel != null)
                {
                    _dbContext.Roles.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelRole(Role RoleName)
        {
            try
            {
                _dbContext.Roles.Remove(RoleName);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<Role>> GetAllRole()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int RoleId)
        {
            return await _dbContext.Roles.Where(p => p.RoleId.Equals(RoleId)).FirstOrDefaultAsync(); ;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(Role role)
        {
            _dbContext.Roles.Update(role);
        }

        public bool UpRole(Role role)
        {
            try
            {
                _dbContext.Roles.Update(role);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
