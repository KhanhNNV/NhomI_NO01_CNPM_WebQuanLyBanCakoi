using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.InterfaceRepository
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllContact();
        Boolean DeleteContact(int id);
        Boolean DeleteContact(Contact contact);
        Boolean UpdateContact(Contact contact);
        Boolean AddContact(Contact contact);
        Task<Contact> GetContactById(int id);
    }
}
