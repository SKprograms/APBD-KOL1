namespace WebApplication1.Models;

public class BookingDTO
{ 
    public DateTime Date { get; set; }
    public GuestDTO Guest { get; set; }
    public EmployeeDTO Employee { get; set; }
    public List<AttractionsInfo> AttractionsInfos { get; set; }
}

public class AttractionsInfo
{
    public string Name { get; set; }
    public int Prize { get; set; }
    public int Amount { get; set; }
}

public class CreateBookingDTO
{
    public int BookingId { get; set; }
    public int GuestId { get; set; }
    public string EmployeeNumber { get; set; }
    public List<AttractionsInfo> AttractionsInfos { get; set; }
    
}