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
    public class CmtKoiRepository : ICmtKoiRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public CmtKoiRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddCmtKoi(CommentKoi cmtKoi)
        {
            try
            {
                _dbContext.CommentKois.Add(cmtKoi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelCmtKoi(int Id)
        {
            try
            {
                var objDel = _dbContext.CommentKois.Where(p => p.CmtKoiId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.CommentKois.Remove(objDel);
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

        public bool DelCmtKoi(CommentKoi cmtKoi)
        {
            try
            {
                _dbContext.CommentKois.Remove(cmtKoi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<CommentKoi>> GetAllCmtKoi()
        {
            return await _dbContext.CommentKois
                .Include(c => c.Koi)
                .ToListAsync();
        }

        public async Task<CommentKoi> GetCmtKoiById(int Id)
        {
            return await _dbContext.CommentKois
                .Include(c => c.Koi)
                .FirstOrDefaultAsync(o => o.CmtKoiId == Id);
        
        }

        public bool UpCmtKoi(CommentKoi cmtKoi)
        {
            try
            {
                _dbContext.Attach(cmtKoi).State = EntityState.Modified;
                _dbContext.CommentKois.Update(cmtKoi);
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
