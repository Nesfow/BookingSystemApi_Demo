namespace Shared;

public record Error
{
    public string Description { get; }

    public ErrorType Type { get; }

    public Error(string description, ErrorType type)
    {
        Description = description;
        Type = type;
    }
}