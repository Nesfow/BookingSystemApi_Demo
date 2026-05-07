using BookingSystemApi.Application.Abstractions.Data;
using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Extensions;

using Microsoft.EntityFrameworkCore;

using Shared;

namespace BookingSystemApi.Application.Features.User.GetUserById;

internal sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, GetUserByIdDto>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetUserByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<GetUserByIdDto>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var userDetails = await _applicationDbContext.Users
            .Where(x => x.Id == query.UserId)
            .FirstOrDefaultAsync(cancellationToken);

        return userDetails is null ?
            new Error("User not found", ErrorType.NotFound) :
            userDetails.ToUserByIdDto();
    }
}