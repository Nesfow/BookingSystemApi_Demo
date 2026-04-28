using BookingSystemApi.Application.Abstractions.Data;
using BookingSystemApi.Application.Abstractions.Messaging;

using Microsoft.EntityFrameworkCore;

using Shared;

namespace BookingSystemApi.Application.Features.Location.CreateLocation;

internal sealed class CreateLocationCommandHandler : ICommandHandler<CreateLocationCommand, int>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateLocationCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<int>> Handle(CreateLocationCommand command, CancellationToken cancellationToken)
    {
        var location = await _applicationDbContext.Locations
            .Where(x => x.Address == command.CreateLocationDto.Address)
            .FirstOrDefaultAsync(cancellationToken);

        if (location is not null)
        {
            return new Error("Location at this address already exists.", ErrorType.Conflict);
        }

        var newLocation = new Domain.Entities.Location()
        {
            Name = command.CreateLocationDto.Name,
            Address = command.CreateLocationDto.Address,
            Capacity = command.CreateLocationDto.Capacity
        };


        _applicationDbContext.Locations.Add(newLocation);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return newLocation.Id;
    }

}