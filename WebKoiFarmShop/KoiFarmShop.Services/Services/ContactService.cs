using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using KoiFarmShop.Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public bool AddContact(Contact contact)
        {
            return _contactRepository.AddContact(contact);
        }

        public bool DeleteContact(int id)
        {
            return _contactRepository.DeleteContact(id);
        }

        public bool DeleteContact(Contact contact)
        {
            return _contactRepository.DeleteContact(contact);
        }

        public Task<List<Contact>> GetAllContact()
        {
            return _contactRepository.GetAllContact();
        }

        public Task<Contact> GetContactById(int id)
        {
            return _contactRepository.GetContactById(id);
        }

        public bool UpdateContact(Contact contact)
        {
            return _contactRepository.UpdateContact(contact);
        }
    }
}
