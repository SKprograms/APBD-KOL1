using Microsoft.AspNetCore.Mvc;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }


    [HttpGet("api/bookings/{id}")]
    public async Task<IActionResult> GetBooking(int id)
    {
        var booking = await _bookingService.getBookingByIdAsync
            .Include(b => b.Guest)
            .Include(b => b.Employee)
            .Include(b => b.BookingAttractions)
            .ThenInclude(ba => ba.Attraction)
            .FirstOrDefaultAsync(b => b.BookingId == id);

        if (booking == null)
        {
            return NotFound(new { message = "Rezerwacja nie istnieje." });
        }

        return Ok(new
        {
            date = booking.Date,
            guest = new
            {
                booking.Guest.FirstName,
                booking.Guest.LastName,
                booking.Guest.DateOfBirth
            },
            employee = new
            {
                booking.Employee.FirstName,
                booking.Employee.LastName,
                booking.Employee.EmployeeNumber
            },
            attractions = booking.BookingAttractions.Select(ba => new
            {
                name = ba.Attraction.Name,
                price = ba.Attraction.Price,
                amount = ba.Amount
            })
        });
    }
}
