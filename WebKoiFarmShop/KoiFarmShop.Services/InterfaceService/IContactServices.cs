using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
namespace KoiFarmShop.Services.InterfaceService
{
    public interface IContactServices
    {
        Task<List<Contact>> Contacts();
        Boolean DelContact(int Id);
        Boolean DelContact(Contact Contacthtml);
        Boolean AddContact(Contact Contacthtml);
        Boolean UpdateContact(Contact Contacthtml);
        Task<Contact> GetContactbyId(int Id);
    }
}
