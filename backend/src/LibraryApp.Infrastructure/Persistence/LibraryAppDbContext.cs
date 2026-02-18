using LibraryApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Infrastructure.Persistence;

public sealed class LibraryAppDbContext : DbContext
{
    public LibraryAppDbContext(DbContextOptions<LibraryAppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).HasMaxLength(200).IsRequired();
            entity.Property(x => x.Author).HasMaxLength(200).IsRequired();
            entity.Property(x => x.UpdatedDate).IsRequired();
            entity.Property(x => x.IsAvailable).IsRequired();
            entity.Property(x => x.IsArchived).IsRequired();
        });
    }
}
