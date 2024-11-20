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
    public class ContactRepository : IContactRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public ContactRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddContact(Contact contact)
        {
            try
            {
                _dbContext.Contacts.Add(contact);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DeleteContact(int id)
        {
            try
            {
                var objDel = _dbContext.Contacts.Where(p => p.ContactId.Equals(id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Contacts.Remove(objDel);
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

        public bool DeleteContact(Contact contact)
        {
            try
            {
                _dbContext.Contacts.Remove(contact);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<Contact>> GetAllContact()
        {
            return await _dbContext.Contacts.Include(b => b.User)
                .ToListAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _dbContext.Contacts.Include(o => o.User)
                .FirstOrDefaultAsync(o => o.ContactId == id);
        }

        public bool UpdateContact(Contact contact)
        {
            try
            {
                _dbContext.Attach(contact).State = EntityState.Modified;
                _dbContext.Contacts.Update(contact);
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
