using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using KoiFarmShop.Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public bool AddBooking(Booking booking)
        {
            return _bookingRepository.AddBooking(booking);
        }

        public bool DeleteBooking(int id)
        {
            return _bookingRepository.DeleteBooking(id);
        }

        public bool DeleteBooking(Booking booking)
        {
            return _bookingRepository.DeleteBooking(booking);
        }

        public Task<List<Booking>> GetAllBooking()
        {
            return _bookingRepository.GetAllBooking();
        }

        public Task<Booking> GetBookingById(int id, int userId)
        {
            return _bookingRepository.GetBookingById(id, userId);
        }

        public Task<Booking> GetBookingById(int id)
        {
            return _bookingRepository.GetBookingById(id);
        }

        public Task<List<Booking>> GetBookingByUserId(int userId)
        {
            return _bookingRepository.GetBookingByUserId(userId);
        }

        public bool UpdateBooking(Booking booking)
        {
            return _bookingRepository.UpdateBooking(booking);
        }
    }
}
