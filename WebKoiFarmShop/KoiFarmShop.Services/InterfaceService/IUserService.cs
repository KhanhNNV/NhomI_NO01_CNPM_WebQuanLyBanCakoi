using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.InterfaceService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUser();
        Boolean DelUser(int UserId);
        Boolean DelUser(User UserName);
        Boolean AddUser(User UserName);
        Boolean UpUser(User user);
        Task<User> GetUserById(int UserId);
    }
}
