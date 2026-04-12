using BookingSystemApi.Domain.Enums;

namespace BookingSystemApi.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
    public DateTimeOffset BookingDate { get; set; }
    public decimal Price { get; set; }
    public BookingStatus BookingStatus { get; set; } = BookingStatus.Pending;

    public User User { get; set; } = null!;
    public Event Event { get; set; } = null!;
    public List<EventSeat> BookedSeats { get; set; } = [];
    public List<Payment> Payments { get; set; } = [];

    private Booking() { } // for ef core migrations

    public decimal CalculatePrice()
    {
        return BookedSeats.Sum(s => s.Price);
    }
}