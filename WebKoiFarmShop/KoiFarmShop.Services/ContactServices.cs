using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using KoiFarmShop.Services.InterfaceService;
using System;

namespace KoiFarmShop.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IContactRepository _repository;
        public ContactServices(IContactRepository repository)
        {
            _repository = repository;
        }
        public bool AddContact(Contact Contacthtml)
        {
            return _repository.AddContact(Contacthtml);
        }

        public Task<List<Contact>> Contacts()
        {
            return _repository.GetAllContact();
        }

        public bool DelContact(int Id)
        {
            return _repository.DelContact(Id);
        }

        public bool DelContact(Contact Contacthtml)
        {
            return (_repository.DelContact(Contacthtml));
        }

        public Task<Contact> GetContactbyId(int Id)
        {
            return _repository.GetContactbyId(Id);
        }

        public bool UpdateContact(Contact Contacthtml)
        {
            return _repository.UpdateContact(Contacthtml);
        }
    }
}
