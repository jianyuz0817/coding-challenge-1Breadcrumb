using LibraryApp.Application.DTOs;
using MediatR;

namespace LibraryApp.Application.UseCases.Books.Queries.SearchBooks;

public sealed record SearchBooksQuery(string Title) : IRequest<IReadOnlyList<BookDto>>;
