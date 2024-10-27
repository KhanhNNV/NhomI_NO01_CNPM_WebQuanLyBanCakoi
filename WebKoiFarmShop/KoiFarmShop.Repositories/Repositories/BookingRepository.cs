﻿using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public BookingRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddBooking(Booking booking)
        {
            try
            {
                _dbContext.Bookings.Add(booking);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DeleteBooking(int id)
        {
            try
            {
                var objDel = _dbContext.Bookings.Where(p => p.BookingId.Equals(id)).FirstOrDefault();
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

        public bool DeleteBooking(Booking booking)
        {
            try
            {
                _dbContext.Bookings.Remove(booking);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<Booking>> GetAllBooking()
        {
            return await _dbContext.Bookings
                .Include(b => b.Cate)
                .Include(b => b.Customer).ToListAsync();
        }

        public async Task<Booking> GetBookingById(int id)
        {
            return await _dbContext.Bookings
               .Include(b => b.Cate)
               .Include(b => b.Customer).FirstOrDefaultAsync(o=>o.BookingId == id);
        }

        public bool UpdateBooking(Booking booking)
        {
            try
            {
                _dbContext.Attach(booking).State = EntityState.Modified;
                _dbContext.Bookings.Update(booking);
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