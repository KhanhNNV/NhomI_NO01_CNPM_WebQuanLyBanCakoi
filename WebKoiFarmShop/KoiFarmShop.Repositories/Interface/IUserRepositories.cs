using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Interface
{
    public interface IUserRepositories
    {
        Task<List<User>> GetAllUser();
        Boolean DelUser(int UserId);
        Boolean DelUser(User UserName);
        Boolean AddUser(User UserName);
        Boolean UpUser(User User);
        Task<User> GetUserById(int UserId);
    }
}
