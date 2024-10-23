using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using KoiFarmShop.Services.InterfaceService;
using System;

namespace KoiFarmShop.Services
{
    public class BookingServices : IBookingServices
    {
        private readonly IBookingRepository _Repository;
        public BookingServices(IBookingRepository Repository) 
        { 
            _Repository = Repository;
        }

        public bool AddBooking(Booking Bookinghtml)
        {
            return _Repository.AddBooking(Bookinghtml);
        }

        public Task<List<Booking>> Bookings()
        {
            return _Repository.GetAllBookings();
        }

        public bool DelBooking(int Id)
        {
            return _Repository.DelBooking(Id);
        }

        public bool DelBooking(Booking Bookinghtml)
        {
           return (_Repository.DelBooking(Bookinghtml));
        }

        public Task<Booking> GetBookingbyId(int Id)
        {
            return _Repository.GetBookingbyId(Id);  
        }

        public bool UpdateBooking(Booking Bookinghtml)
        {
            return _Repository.UpdateBooking(Bookinghtml);
        }
    }
}