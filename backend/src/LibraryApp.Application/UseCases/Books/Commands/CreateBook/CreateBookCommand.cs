using LibraryApp.Application.DTOs;
using MediatR;

namespace LibraryApp.Application.UseCases.Books.Commands.CreateBook;

public sealed record CreateBookCommand(
    string Title,
    string Author,
    bool IsAvailable
) : IRequest<BookDto>;
