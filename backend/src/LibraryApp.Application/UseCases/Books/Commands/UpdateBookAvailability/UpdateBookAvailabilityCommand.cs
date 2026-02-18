using LibraryApp.Application.DTOs;
using MediatR;

namespace LibraryApp.Application.UseCases.Books.Commands.UpdateBookAvailability;

public sealed record UpdateBookAvailabilityCommand(Guid Id, bool IsAvailable) : IRequest<BookDto>;
