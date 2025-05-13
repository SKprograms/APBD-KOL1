using WebApplication1.Services;

namespace WebApplication1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddScoped<IBookingService, BookingService>();
        
        var app = builder.Build();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}