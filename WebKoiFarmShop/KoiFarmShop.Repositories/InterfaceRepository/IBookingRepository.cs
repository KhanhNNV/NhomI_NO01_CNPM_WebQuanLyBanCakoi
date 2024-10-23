using KoiFarmShop.Repositories.Entities;
using System;
namespace KoiFarmShop.Repositories.InterfaceRepository
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookings();
        Boolean DelBooking(int Id);
        Boolean DelBooking(Booking Bookinghtml);
        Boolean AddBooking(Booking Bookinghtml);
        Boolean UpdateBooking(Booking Bookinghtml);
        Task<Booking> GetBookingbyId(int Id);
    }
}
