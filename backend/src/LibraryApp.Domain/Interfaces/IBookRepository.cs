using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Interfaces;

public interface IBookRepository
{
    Task<IReadOnlyList<Book>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<int> CountAsync(CancellationToken cancellationToken);
    Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Book>> SearchByTitleAsync(string title, CancellationToken cancellationToken);
    Task AddAsync(Book book, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
