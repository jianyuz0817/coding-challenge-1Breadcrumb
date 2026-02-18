namespace LibraryApp.Domain.Exceptions;

public sealed class BookNotFoundException : Exception
{
    public BookNotFoundException(Guid id)
        : base($"Book with id '{id}' was not found.")
    {
    }
}
