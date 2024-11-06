using KoiFarmShop.Repositories.InterfaceRepository;
using KoiFarmShop.Repositories.Repositories;
using KoiFarmShop.Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _identityRepository;
        public IdentityService(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public string GetUserNameCall()
        {
            return _identityRepository.GetUserNameCall();
        }

        public bool IsSignedInCall()
        {
            return _identityRepository.IsSignedInCall();
        }

    }
}
