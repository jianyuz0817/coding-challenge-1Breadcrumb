using FluentValidation;

namespace LibraryApp.Application.UseCases.Books.Queries.SearchBooks;

public sealed class SearchBooksValidator : AbstractValidator<SearchBooksQuery>
{
    public SearchBooksValidator()
    {
        //TODO: Add validation rules for the search query parameters, such as:
    }
}
