using LibraryApp.Application.DTOs;
using MediatR;

namespace LibraryApp.Application.UseCases.Books.Queries.GetBookById;

public sealed record GetBookByIdQuery(Guid Id) : IRequest<BookDto>;
