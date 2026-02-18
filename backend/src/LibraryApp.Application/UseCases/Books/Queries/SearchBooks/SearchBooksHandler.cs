using LibraryApp.Application.DTOs;
using LibraryApp.Domain.Interfaces;
using MediatR;

namespace LibraryApp.Application.UseCases.Books.Queries.SearchBooks;

public sealed class SearchBooksHandler : IRequestHandler<SearchBooksQuery, IReadOnlyList<BookDto>>
{
    private readonly IBookRepository _repository;

    public SearchBooksHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<BookDto>> Handle(SearchBooksQuery request, CancellationToken cancellationToken)
    {
        //TODO: Implement search logic in the repository and return the results as a list of BookDto
        throw new NotImplementedException();
    }
}
