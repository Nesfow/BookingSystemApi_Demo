namespace BookingSystemApi.Domain.Exceptions.Event;

public class CapacityExceededException : DomainException
{
    public CapacityExceededException(int capacity)
        : base($"Cannot add seat because event capacity of {capacity} would be exceeded.")
    {
    }
}
