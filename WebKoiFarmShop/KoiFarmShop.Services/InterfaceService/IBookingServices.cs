using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
namespace KoiFarmShop.Services.InterfaceService
{
    public interface IBookingServices
    {
        Task<List<Booking>> Bookings();
        Boolean DelBooking(int Id);
        Boolean DelBooking(Booking Bookinghtml);
        Boolean AddBooking(Booking Bookinghtml);
        Boolean UpdateBooking(Booking Bookinghtml);
        Task<Booking> GetBookingbyId(int Id);
    }
}
