using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Infrastructure.Persistence.Repositories;

public sealed class BookRepository : IBookRepository
{
    private readonly LibraryAppDbContext _context;

    public BookRepository(LibraryAppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Book>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await _context.Books
            .AsNoTracking()
            .Where(b => !b.IsArchived)
            .OrderBy(b => b.Title)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken)
    {
        return await _context.Books.CountAsync(b => !b.IsArchived, cancellationToken);
    }

    public async Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Book>> SearchByTitleAsync(string title, CancellationToken cancellationToken)
    {
        var normalized = title.Trim().ToLowerInvariant();
        return await _context.Books
            .AsNoTracking()
            .Where(b => !b.IsArchived && b.Title.ToLower().Contains(normalized))
            .OrderBy(b => b.Title)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Book book, CancellationToken cancellationToken)
    {
        await _context.Books.AddAsync(book, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
