namespace BookingSystemApi.Domain.Exceptions.Event;

public class DuplicateSeatLabelException : DomainException
{
    public DuplicateSeatLabelException(string label)
        : base($"Seat with the label '{label}' already exists.")
    {
    }
}
