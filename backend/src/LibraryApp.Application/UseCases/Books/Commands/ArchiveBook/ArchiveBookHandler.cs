using LibraryApp.Domain.Interfaces;
using MediatR;

namespace LibraryApp.Application.UseCases.Books.Commands.ArchiveBook;

public sealed class ArchiveBookHandler : IRequestHandler<ArchiveBookCommand>
{
    private readonly IBookRepository _repository;

    public ArchiveBookHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(ArchiveBookCommand request, CancellationToken cancellationToken)
    {
        //TODO: archive book on id
        throw new NotImplementedException();
    }
}
