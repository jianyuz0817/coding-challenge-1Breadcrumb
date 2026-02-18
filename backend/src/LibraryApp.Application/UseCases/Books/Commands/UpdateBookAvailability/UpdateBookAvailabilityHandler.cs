using LibraryApp.Application.DTOs;
using LibraryApp.Domain.Exceptions;
using LibraryApp.Domain.Interfaces;
using MediatR;

namespace LibraryApp.Application.UseCases.Books.Commands.UpdateBookAvailability;

public sealed class UpdateBookAvailabilityHandler : IRequestHandler<UpdateBookAvailabilityCommand, BookDto>
{
    private readonly IBookRepository _repository;

    public UpdateBookAvailabilityHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<BookDto> Handle(UpdateBookAvailabilityCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (book is null || book.IsArchived)
        {
            throw new BookNotFoundException(request.Id);
        }

        book.IsAvailable = request.IsAvailable;
        book.UpdatedDate = DateTime.UtcNow;

        await _repository.SaveChangesAsync(cancellationToken);

        return BookDto.FromEntity(book);
    }
}
