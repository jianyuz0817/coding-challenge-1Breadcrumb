using LibraryApp.Application.DTOs;
using LibraryApp.Domain.Interfaces;
using MediatR;

namespace LibraryApp.Application.UseCases.Books.Queries.GetBookById;

public sealed class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookDto>
{
    private readonly IBookRepository _repository;

    public GetBookByIdHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        //TODO: Implement the logic to retrieve a book by its ID from the repository and return a BookDto.
        throw new NotImplementedException();
    }
}
