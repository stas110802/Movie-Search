namespace MovieSearch.Infrastructure.Common;

public abstract class BaseEndpoint(string value)
{
    public string Value { get; init; } = value;
}