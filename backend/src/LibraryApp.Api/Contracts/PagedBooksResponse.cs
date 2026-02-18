namespace LibraryApp.Api.Contracts;

public sealed class PagedBooksResponse
{
    public IReadOnlyList<BookResponse> Items { get; init; } = new List<BookResponse>();
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
}
