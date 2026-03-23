using BookingSystemApi.Domain.Enums;

namespace BookingSystemApi.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public User User { get; set; } = null!;
    public Event Event { get; set; } = null!;
    public DateTimeOffset BookingDate { get; set; }
    public decimal Price { get; set; }
    public BookingStatus BookingStatus { get; set; } = BookingStatus.Pending;
    public List<EventSeat> BookedSeats { get; set; } = [];
    private readonly List<Payment> _payments = [];
    public IReadOnlyCollection<Payment> Payments => _payments;

    public decimal CalculatePrice()
    {
        return BookedSeats.Sum(s => s.Price);
    }

    public void AddPayment(Payment payment)
    {
        ArgumentNullException.ThrowIfNull(payment);
        _payments.Add(payment);
    }
}