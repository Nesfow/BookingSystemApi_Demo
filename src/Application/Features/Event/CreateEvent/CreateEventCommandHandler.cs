using BookingSystemApi.Application.Abstractions.Messaging;
using Shared;

namespace BookingSystemApi.Application.Features.Event.CreateEvent;

internal sealed class CreateEventCommandHandler : ICommandHandler<CreateEventCommand, int>
{
    public Task<Result<int>> Handle(CreateEventCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}