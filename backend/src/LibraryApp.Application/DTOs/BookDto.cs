using LibraryApp.Domain.Entities;

namespace LibraryApp.Application.DTOs;

public sealed class BookDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
    public DateTime UpdatedDate { get; init; }
    public bool IsAvailable { get; init; }

    public static BookDto FromEntity(Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            UpdatedDate = book.UpdatedDate,
            IsAvailable = book.IsAvailable
        };
    }
}
