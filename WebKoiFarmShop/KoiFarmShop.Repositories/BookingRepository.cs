using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;

namespace KoiFarmShop.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public BookingRepository(KoiFarmShopDbContext dbcontext) 
        {
            _dbContext = dbcontext;
        }

        public bool AddBooking(Booking Bookinghtml)
        {
            try
            {
                _dbContext.Bookings.Add(Bookinghtml);
                _dbContext.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                throw new NotImplementedException();
            }
            
        }

        public bool DelBooking(int Id)
        {
            try
            {
                var objDel = _dbContext.Bookings.Where(p=>p.BookingId == Id).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Bookings.Remove(objDel);
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

        public bool DelBooking(Booking Bookinghtml)
        {
            try
            {
                _dbContext.Bookings.Remove(Bookinghtml);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
                return false;
            }
        }

        public async Task<List<Booking>> GetAllBookings()
        {
            return await _dbContext.Bookings.ToListAsync();
        }

        public async Task<Booking> GetBookingbyId(int Id)
        {
            return await _dbContext.Bookings.Where(p => p.BookingId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdateBooking(Booking Bookinghtml)
        {
            try
            {
                _dbContext.Bookings.Update(Bookinghtml);
                return true;
            } catch (Exception ex)
            {
                return false;
            }

        }
    }
}