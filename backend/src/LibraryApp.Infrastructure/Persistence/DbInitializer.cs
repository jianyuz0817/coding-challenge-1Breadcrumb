using LibraryApp.Domain.Entities;

namespace LibraryApp.Infrastructure.Persistence;

public static class DbInitializer
{
    public static void Seed(LibraryAppDbContext context)
    {
        if (context.Books.Any())
        {
            return;
        }

        var now = DateTime.UtcNow;
        context.Books.AddRange(
            new Book
            {
                Id = Guid.NewGuid(),
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt",
                UpdatedDate = now,
                IsAvailable = true,
                IsArchived = false
            },
            new Book
            {
                Id = Guid.NewGuid(),
                Title = "Clean Code",
                Author = "Robert C. Martin",
                UpdatedDate = now,
                IsAvailable = false,
                IsArchived = false
            },
            new Book
            {
                Id = Guid.NewGuid(),
                Title = "Designing Data-Intensive Applications",
                Author = "Martin Kleppmann",
                UpdatedDate = now,
                IsAvailable = true,
                IsArchived = false
            }
        );

        context.SaveChanges();
    }
}
