using WebApplication1.Models;

namespace WebApplication1.Services;

public class IBookingService
{
    Task<BookingDTO> GetBookingByIdAsync(int bookingId);
    Task<int> CreateBookingAsync(BookingDTO booking);
}