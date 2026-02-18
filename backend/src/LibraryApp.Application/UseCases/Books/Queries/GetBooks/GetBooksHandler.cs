using LibraryApp.Application.DTOs;
using LibraryApp.Domain.Interfaces;
using MediatR;

namespace LibraryApp.Application.UseCases.Books.Queries.GetBooks;

public sealed class GetBooksHandler : IRequestHandler<GetBooksQuery, PagedResultDto<BookDto>>
{
    private readonly IBookRepository _repository;

    public GetBooksHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResultDto<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var items = await _repository.GetPagedAsync(request.PageNumber, request.PageSize, cancellationToken);
        var total = await _repository.CountAsync(cancellationToken);

        return new PagedResultDto<BookDto>
        {
            Items = items.Select(BookDto.FromEntity).ToList(),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = total
        };
    }
}
