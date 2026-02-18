using LibraryApp.Application.DTOs;
using MediatR;

namespace LibraryApp.Application.UseCases.Books.Queries.GetBooks;

public sealed record GetBooksQuery(int PageNumber, int PageSize) : IRequest<PagedResultDto<BookDto>>;
