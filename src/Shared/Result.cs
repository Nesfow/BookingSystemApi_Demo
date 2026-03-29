using System.Diagnostics.CodeAnalysis;

namespace Shared;

public record Result
{
    public bool IsSuccess { get; set; }
    public Error? Error { get; set; }

    public Result(bool isSuccess, Error? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, null);
    public static Result Failure(Error error) => new(false, error);

    // A small shortcut to use an error in the falied return instead of conversion to Result
    public static implicit operator Result(Error error) => Failure(error);
}

public record Result<TValue> : Result
{
    private readonly TValue? _value;

    [NotNull]
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can't be accessed.");

    public Result(TValue? value, bool isSuccess, Error? error) : base(isSuccess, error)
    {
        _value = value;
    }

    public Result(Error error) : base(false, error) { }

    public static implicit operator Result<TValue>(TValue? value) => new(value, true, null);
    public static implicit operator Result<TValue>(Error error) => new(error);

}
