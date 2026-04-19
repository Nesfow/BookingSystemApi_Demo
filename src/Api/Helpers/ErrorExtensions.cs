using Shared;

namespace BookingSystemApi.Api.Helpers;

public static class ErrorExtensions
{
    public static IResult ToHttpResult(this Error error)
    {
        var apiError = new ApiError(error.Type.ToString(), error.Description);

        return error.Type switch
        {
            ErrorType.NotFound => Results.NotFound(apiError),
            ErrorType.Conflict => Results.Conflict(apiError),
            _ => Results.BadRequest(apiError)
        };
    }
}