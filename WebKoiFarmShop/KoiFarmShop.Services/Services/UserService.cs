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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepositories;
        public UserService(IUserRepository userRepositories)
        {
            _userRepositories = userRepositories;
        }


        public bool AddUser(User UserName)
        {
            return _userRepositories.AddUser(UserName);
        }

        public bool DelUser(int UserId)
        {
            return _userRepositories.DelUser(UserId);
        }

        public bool DelUser(User UserName)
        {
            return _userRepositories.DelUser(UserName);
        }
        public async Task<User> GetUserById(int UserId)
        {
            return await _userRepositories.GetUserById(UserId);
        }

        public bool UpUser(User user)
        {
            return _userRepositories.UpUser(user);
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _userRepositories.GetAllUser();
        }
    }
}
