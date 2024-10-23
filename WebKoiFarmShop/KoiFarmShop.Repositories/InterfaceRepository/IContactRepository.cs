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

        Boolean DelContact(int Id);
        Boolean DelContact(Contact Contacthtml);
        Boolean AddContact(Contact Contacthtml);
        Boolean UpdateContact(Contact Contacthtml);
        Task<Contact> GetContactbyId(int Id);
    }
}
