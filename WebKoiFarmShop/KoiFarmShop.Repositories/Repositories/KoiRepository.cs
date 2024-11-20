using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Repositories
{
    public class KoiRepository : IKoiRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public KoiRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddKOi(Koi koi)
        {
            try
            {
                _dbContext.Kois.Add(koi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelKoi(int Id)
        {
            try
            {
                var objDel = _dbContext.Kois.Where(p => p.KoiId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Kois.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelKoi(Koi koi)
        {
            try
            {
                _dbContext.Kois.Remove(koi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<Koi>> GetAllKoi()
        {
            return await _dbContext.Kois.Include(u => u.KoiCate).ToListAsync();
        }

        public async Task<List<Koi>> GetKoiByKoiCateId(int KoiCateId)
        {
            return await _dbContext.Kois.Where(k => k.KoiCateId == KoiCateId).ToListAsync();
        }

        public async Task<Koi> GetKOiById(int Id)
        {
            return await _dbContext.Kois.Include(o => o.KoiCate).FirstOrDefaultAsync(o => o.KoiId == Id);
        }
        

        public bool UpKoi(Koi koi)
        {
            try
            {
                _dbContext.Attach(koi).State = EntityState.Modified;
                _dbContext.Kois.Update(koi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
