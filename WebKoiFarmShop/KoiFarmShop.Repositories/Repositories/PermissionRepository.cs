using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Repositories
{
    public class PermissionRepository : IPermissionReposirory
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public PermissionRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddPermission(Permission permission)
        {
            try
            {
                _dbContext.Permissions.Add(permission);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DeletePermission(int id)
        {
            try
            {
                var objDel = _dbContext.Permissions.Where(p => p.PermissionId.Equals(id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Permissions.Remove(objDel);
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

        public bool DeletePermission(Permission permission)
        {
            try
            {
                _dbContext.Permissions.Remove(permission);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<Permission>> GetAllPermission()
        {
            return await _dbContext.Permissions.ToListAsync();
        }

        public async Task<Permission> GetPermissionById(int id)
        {
            return await _dbContext.Permissions.FirstOrDefaultAsync(o => o.PermissionId == id);
        }

        public bool UpdatePermission(Permission permission)
        {
            try
            {
                _dbContext.Attach(permission).State = EntityState.Modified;
                _dbContext.Permissions.Update(permission);
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
