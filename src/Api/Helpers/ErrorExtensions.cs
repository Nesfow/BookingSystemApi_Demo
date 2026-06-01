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
            ErrorType.Failure => Results.InternalServerError(apiError),
            ErrorType.Problem => Results.InternalServerError(apiError),
            ErrorType.Validation => Results.BadRequest(apiError),
            _ => Results.BadRequest(apiError)
        };
    }
}