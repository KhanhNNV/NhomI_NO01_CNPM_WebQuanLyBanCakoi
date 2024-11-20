using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.InterfaceService
{
    public interface IIdentityService
    {
        Boolean IsSignedInCall();

        string GetUserNameCall();

    }
}
