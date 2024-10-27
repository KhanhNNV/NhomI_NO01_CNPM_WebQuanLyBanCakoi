﻿using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.InterfaceService
{
    public interface IBookingService
    {
        Task<List<Booking>> GetAllBooking();
        Boolean DeleteBooking(int id);
        Boolean DeleteBooking(Booking booking);
        Boolean UpdateBooking(Booking booking);
        Boolean AddBooking(Booking booking);
        Task<Booking> GetBookingById(int id);
    }
}