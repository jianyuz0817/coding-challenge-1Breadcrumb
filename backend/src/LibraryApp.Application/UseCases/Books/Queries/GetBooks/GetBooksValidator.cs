using FluentValidation;

namespace LibraryApp.Application.UseCases.Books.Queries.GetBooks;

public sealed class GetBooksValidator : AbstractValidator<GetBooksQuery>
{
    public GetBooksValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0).LessThanOrEqualTo(100);
    }
}
