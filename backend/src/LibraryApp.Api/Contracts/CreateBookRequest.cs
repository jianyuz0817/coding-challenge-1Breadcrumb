namespace LibraryApp.Api.Contracts;

public sealed class CreateBookRequest
{
    public string Title { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
    public bool IsAvailable { get; init; }
}
