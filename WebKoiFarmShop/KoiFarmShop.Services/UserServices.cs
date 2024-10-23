using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interface;
using KoiFarmShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepositories _userRepositories;
        public UserServices(IUserRepositories userRepositories)
        {
            _userRepositories = userRepositories;
        }

        public object Roles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public Task<List<User>> User()
        {
            return _userRepositories.GetAllUser();
        }
    }
}
