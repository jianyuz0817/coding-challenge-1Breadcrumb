namespace LibraryApp.Domain.Entities;

public sealed class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTime UpdatedDate { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsArchived { get; set; }
}
