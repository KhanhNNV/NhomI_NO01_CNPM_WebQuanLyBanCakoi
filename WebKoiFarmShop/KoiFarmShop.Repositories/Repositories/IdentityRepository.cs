using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace KoiFarmShop.Repositories.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimsPrincipal user => _httpContextAccessor.HttpContext.User;

        public IdentityRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsSignedInCall()
        {
            
            return _signInManager.IsSignedIn(user);

        }

        public string GetUserNameCall()
        {
            return _userManager.GetUserName(user);
        }

    }
}

