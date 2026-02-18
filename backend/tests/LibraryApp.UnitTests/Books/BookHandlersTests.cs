using FluentAssertions;
using LibraryApp.Application.UseCases.Books.Commands.ArchiveBook;
using LibraryApp.Application.UseCases.Books.Commands.CreateBook;
using LibraryApp.Application.UseCases.Books.Commands.UpdateBookAvailability;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Exceptions;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.UnitTests.Books;

public sealed class BookHandlersTests
{
    [Fact]
    public async Task CreateBookHandler_ShouldCreateBook()
    {
        var repository = new InMemoryBookRepository();
        var handler = new CreateBookHandler(repository);

        var command = new CreateBookCommand(
            "New Book",
            "Author Name",
            "1234567890",
            new DateTime(2020, 1, 1),
            true);

        var result = await handler.Handle(command, CancellationToken.None);

        repository.Books.Should().ContainSingle(b => b.Id == result.Id);
        result.Title.Should().Be("New Book");
        result.IsAvailable.Should().BeTrue();
    }

    [Fact]
    public async Task UpdateBookAvailabilityHandler_ShouldUpdateAvailability()
    {
        var repository = new InMemoryBookRepository();
        var book = new Book
        {
            Id = Guid.NewGuid(),
            Title = "Existing",
            Author = "Someone",
            UpdatedDate = new DateTime(2010, 1, 1),
            IsAvailable = false,
            IsArchived = false
        };
        repository.Seed(book);

        var handler = new UpdateBookAvailabilityHandler(repository);

        var result = await handler.Handle(new UpdateBookAvailabilityCommand(book.Id, true), CancellationToken.None);

        result.IsAvailable.Should().BeTrue();
        repository.Books.Single(b => b.Id == book.Id).IsAvailable.Should().BeTrue();
    }

    [Fact]
    public async Task ArchiveBookHandler_ShouldArchiveBook()
    {
        var repository = new InMemoryBookRepository();
        var book = new Book
        {
            Id = Guid.NewGuid(),
            Title = "Existing",
            Author = "Someone",
            UpdatedDate = new DateTime(2010, 1, 1),
            IsAvailable = true,
            IsArchived = false
        };
        repository.Seed(book);

        var handler = new ArchiveBookHandler(repository);

        await handler.Handle(new ArchiveBookCommand(book.Id), CancellationToken.None);

        repository.Books.Single(b => b.Id == book.Id).IsArchived.Should().BeTrue();
    }

    [Fact]
    public async Task ArchiveBookHandler_ShouldThrowWhenMissing()
    {
        var repository = new InMemoryBookRepository();
        var handler = new ArchiveBookHandler(repository);

        var action = async () => await handler.Handle(new ArchiveBookCommand(Guid.NewGuid()), CancellationToken.None);

        await action.Should().ThrowAsync<BookNotFoundException>();
    }

    private sealed class InMemoryBookRepository : IBookRepository
    {
        private readonly List<Book> _books = new();

        public IReadOnlyList<Book> Books => _books;

        public Task<IReadOnlyList<Book>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var items = _books.Where(b => !b.IsArchived)
                .OrderBy(b => b.Title)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return Task.FromResult<IReadOnlyList<Book>>(items);
        }

        public Task<int> CountAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_books.Count(b => !b.IsArchived));
        }

        public Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return Task.FromResult(_books.SingleOrDefault(b => b.Id == id));
        }

        public Task<IReadOnlyList<Book>> SearchByTitleAsync(string title, CancellationToken cancellationToken)
        {
            var normalized = title.Trim().ToLowerInvariant();
            var items = _books.Where(b => !b.IsArchived && b.Title.ToLower().Contains(normalized))
                .OrderBy(b => b.Title)
                .ToList();
            return Task.FromResult<IReadOnlyList<Book>>(items);
        }

        public Task AddAsync(Book book, CancellationToken cancellationToken)
        {
            _books.Add(book);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Seed(Book book)
        {
            _books.Add(book);
        }
    }
}
