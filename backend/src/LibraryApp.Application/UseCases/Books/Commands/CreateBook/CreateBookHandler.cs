using LibraryApp.Application.DTOs;
using LibraryApp.Domain.Interfaces;
using MediatR;

namespace LibraryApp.Application.UseCases.Books.Commands.CreateBook;

public sealed class CreateBookHandler : IRequestHandler<CreateBookCommand, BookDto>
{
    private readonly IBookRepository _repository;

    public CreateBookHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        //TODO: create book entity from request and save it to the database
        throw new NotImplementedException();
    }
}
