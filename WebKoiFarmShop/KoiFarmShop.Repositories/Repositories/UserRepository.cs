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
    public class UserRepository :IUserRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public UserRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddUser(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelUser(int id)
        {
            try
            {
                var objDel = _dbContext.Users.Where(p => p.UserId.Equals(id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Users.Remove(objDel);
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
            return await _dbContext.Users.Include(u => u.Role).ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _dbContext.Users.Include(o => o.Role).FirstOrDefaultAsync(o => o.UserId == id);
        }

        public bool UpUser(User User)
        {
            try
            {
                _dbContext.Attach(User).State = EntityState.Modified;
                _dbContext.Users.Update(User);
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
