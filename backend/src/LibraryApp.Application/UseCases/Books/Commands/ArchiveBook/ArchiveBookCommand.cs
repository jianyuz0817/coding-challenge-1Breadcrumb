using MediatR;

namespace LibraryApp.Application.UseCases.Books.Commands.ArchiveBook;

public sealed record ArchiveBookCommand(Guid Id) : IRequest;
