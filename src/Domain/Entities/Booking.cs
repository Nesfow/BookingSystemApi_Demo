using BookingSystemApi.Domain.Enums;

namespace BookingSystemApi.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
    public DateTimeOffset BookingDate { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset PaymentExpirationDate { get; set; }
    public decimal Price { get; set; }
    public BookingStatus BookingStatus { get; set; } = BookingStatus.Pending;

    public User User { get; set; } = null!;
    public Event Event { get; set; } = null!;
    public List<Seat> BookedSeats { get; set; } = [];
    public List<Payment> Payments { get; set; } = [];

    private Booking() { } // for ef core migrations

    public Booking(int userId, int eventId)
    {
        UserId = userId;
        EventId = eventId;
    }

    public decimal CalculatePrice()
    {
        return BookedSeats.Sum(s => s.Price);
    }

    // Simplifying - checking only if booking is made before or at the day of event
    public void CalculatePaymentExpirationDate()
    {
        PaymentExpirationDate = (Event.EventDate - BookingDate).TotalDays >= 7
            ? BookingDate.AddDays(7)
            : Event.EventDate;
    }
}