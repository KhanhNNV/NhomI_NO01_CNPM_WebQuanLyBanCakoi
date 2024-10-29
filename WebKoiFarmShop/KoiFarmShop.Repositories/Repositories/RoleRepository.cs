using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
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
        private readonly KoiFarmShopDbContext _dbContext;
        public RoleRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddRole(Role role)
        {
            try
            {
                _dbContext.Roles.Add(role);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
        public bool DelRole(int id)
        {
            try
            {
                var objDel = _dbContext.Roles.Where(p => p.RoleId.Equals(id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Roles.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelRole(Role role)
        {
            try
            {
                _dbContext.Roles.Remove(role);
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

        public async Task<Role> GetRoleById(int id)
        {
            return await _dbContext.Roles.Where(p => p.RoleId.Equals(id)).FirstOrDefaultAsync();
        }
        public bool UpRole(Role role)
        {
            try
            {
                _dbContext.Attach(role).State = EntityState.Modified;
                _dbContext.Roles.Update(role);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}

