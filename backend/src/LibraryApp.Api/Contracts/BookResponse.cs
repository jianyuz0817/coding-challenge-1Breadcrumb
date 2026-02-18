using LibraryApp.Application.DTOs;

namespace LibraryApp.Api.Contracts;

public sealed class BookResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
    public bool IsAvailable { get; init; }

    public static BookResponse FromDto(BookDto dto)
    {
        return new BookResponse
        {
            Id = dto.Id,
            Title = dto.Title,
            Author = dto.Author,
            IsAvailable = dto.IsAvailable
        };
    }
}
