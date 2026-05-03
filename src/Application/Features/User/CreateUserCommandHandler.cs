using BookingSystemApi.Application.Abstractions.Data;
using BookingSystemApi.Application.Abstractions.Messaging;

using Microsoft.EntityFrameworkCore;

using Shared;

namespace BookingSystemApi.Application.Features.User;

internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, int>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateUserCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<int>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var userToCheck = await _applicationDbContext.Users
            .Where(x => x.Email == command.CreateUserDto.Email)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (userToCheck is not null)
        {
            return new Error("User with this email address already exists.", ErrorType.Conflict);
        }

        var newUser = new Domain.Entities.User(command.CreateUserDto.Name, command.CreateUserDto.Email);

        _applicationDbContext.Users.Add(newUser);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return newUser.Id;
    }
}