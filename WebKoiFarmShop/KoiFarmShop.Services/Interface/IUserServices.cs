using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Interface
{
    public interface IUserServices
    {
        object Roles { get; set; }
        Task<List<User>> User();
        Boolean DelUser(int UserId);
        Boolean DelUser(User UserName);
        Boolean AddUser(User UserName);
        Boolean UpUser(User user);
        Task<User> GetUserById(int UserId);
    }
}
