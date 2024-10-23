using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using System;

namespace KoiFarmShop.Repositories
{
    public class ContactRepository : IContactRepository
    {

        private readonly KoiFarmShopDbContext _dbContext;
        public ContactRepository(KoiFarmShopDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public bool AddContact(Contact Contacthtml)
        {
            throw new NotImplementedException();
        }

        public bool DelContact(int Id)
        {
            throw new NotImplementedException();
        }

        public bool DelContact(Contact Contacthtml)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> GetAllContact()
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetContactbyId(int Id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateContact(Contact Contacthtml)
        {
            throw new NotImplementedException();
        }
    }
}