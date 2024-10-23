using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.InterfaceService
{
    public interface IKoiService
    {
        Task<List<Koi>> GetAllKoi();
        Boolean DelKoi(int Id);
        Boolean DelKoi(Koi koi);
        Boolean AddKOi(Koi koi);
        Boolean UpKoi(Koi koi);
        Task<Koi> GetKOiById(int Id);
    }
}
