using BookingSystemApi.Application.Abstractions.Messaging;

namespace BookingSystemApi.Application.Features.Location.GetLocation;

public sealed record GetLocationQuery(int LocationId) : IQuery<GetLocationDto>;