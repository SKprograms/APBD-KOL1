using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class BookingService: IBookingService
{
    private readonly IConfiguration _configuration;
    public BookingService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<BookingDTO> GetBookingByIdAsync(int bookingId)
    {
        string command = "SELECT date, patient_id, doctor_id FROM Appointment where appoitment_id = @AppoitmentId";
        
        BookingDTO bookingDTO = new BookingDTO();
        int clientId = 0;
        int doctorId = 0;
        
        using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            await conn.OpenAsync();
            cmd.Parameters.AddWithValue("@AppoitmentId", bookingId);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    BookingDTO.Date = reader.GetDateTime(0);
                    clientId = reader.GetInt32(1);
                    doctorId = reader.GetInt32(2);
                }
            }
        }
    }

}