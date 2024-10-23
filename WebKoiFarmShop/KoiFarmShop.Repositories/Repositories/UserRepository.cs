using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public UserRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddUser(User UserName)
        {
            try
            {
                _dbContext.Users.Add(UserName);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool DelUser(int UserId)
        {
            try
            {
                var objDel = _dbContext.Roles.Where(p => p.RoleId.Equals(UserId)).FirstOrDefault();
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

        public bool DelUser(User UserName)
        {
            try
            {
                _dbContext.Users.Remove(UserName);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int UserId)
        {
            return await _dbContext.Users.Where(p => p.RoleId.Equals(UserId)).FirstOrDefaultAsync();
        }

        public bool UpUser(User User)
        {
            try
            {
                _dbContext.Users.Update(User);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
