using LibraryApp.Api.Contracts;
using LibraryApp.Application.UseCases.Books.Commands.ArchiveBook;
using LibraryApp.Application.UseCases.Books.Commands.CreateBook;
using LibraryApp.Application.UseCases.Books.Commands.UpdateBookAvailability;
using LibraryApp.Application.UseCases.Books.Queries.GetBookById;
using LibraryApp.Application.UseCases.Books.Queries.GetBooks;
using LibraryApp.Application.UseCases.Books.Queries.SearchBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers;

[ApiController]
[Route("books")]
public sealed class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PagedBooksResponse>> GetBooks(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetBooksQuery(pageNumber, pageSize), cancellationToken);
        return Ok(new PagedBooksResponse
        {
            Items = result.Items.Select(BookResponse.FromDto).ToList(),
            PageNumber = result.PageNumber,
            PageSize = result.PageSize,
            TotalCount = result.TotalCount
        });
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BookResponse>> GetBookById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetBookByIdQuery(id), cancellationToken);
        return Ok(BookResponse.FromDto(result));
    }

    [HttpGet("search")]
    public async Task<ActionResult<BookResponse[]>> SearchBooks([FromQuery] string title, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new SearchBooksQuery(title), cancellationToken);
        return Ok(result.Select(BookResponse.FromDto).ToArray());
    }

    [HttpPost]
    public async Task<ActionResult<BookResponse>> CreateBook(
        [FromBody] CreateBookRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateBookCommand(
            request.Title,
            request.Author,
            request.IsAvailable);
        var result = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetBookById), new { id = result.Id }, BookResponse.FromDto(result));
    }

    [HttpPatch("{id:guid}/availability")]
    public async Task<ActionResult<BookResponse>> UpdateAvailability(
        Guid id,
        [FromBody] UpdateAvailabilityRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdateBookAvailabilityCommand(id, request.IsAvailable), cancellationToken);
        return Ok(BookResponse.FromDto(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> ArchiveBook(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ArchiveBookCommand(id), cancellationToken);
        return NoContent();
    }
}
