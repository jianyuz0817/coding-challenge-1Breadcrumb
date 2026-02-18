using LibraryApp.Domain.Interfaces;
using LibraryApp.Infrastructure.Persistence;
using LibraryApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<LibraryAppDbContext>(options =>
        {
            options.UseInMemoryDatabase("LibraryAppDb");
        });

        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }
}
