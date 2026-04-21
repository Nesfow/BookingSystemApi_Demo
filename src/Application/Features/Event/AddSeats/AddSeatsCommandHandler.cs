using BookingSystemApi.Application.Abstractions.Data;
using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Extensions;

using Microsoft.EntityFrameworkCore;

using Shared;

namespace BookingSystemApi.Application.Features.Event.AddSeats;

internal sealed class AddSeatsCommandHandler : ICommandHandler<AddSeatsCommand>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public AddSeatsCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result> Handle(AddSeatsCommand command, CancellationToken cancellationToken)
    {
        var thisEvent = await _applicationDbContext.Events
            .Where(x => x.Id == command.EventId)
            .Include(x => x.Location)
            .Include(x => x.Seats)
            .FirstOrDefaultAsync(cancellationToken);

        if (thisEvent is null)
        {
            return Result.Failure(new Error("Seat cannot be added, as event doesn't exist", ErrorType.NotFound));
        }

        var seatsToAdd = command.AddSeatsDtos.Select(x => x.ToSeat()).ToList();
        thisEvent.AddSeats(seatsToAdd);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

}