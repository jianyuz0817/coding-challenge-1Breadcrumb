using FluentValidation;

namespace LibraryApp.Application.UseCases.Books.Queries.GetBookById;

public sealed class GetBookByIdValidator : AbstractValidator<GetBookByIdQuery>
{
    public GetBookByIdValidator()
    {
        //TODO: Add validation rules if needed.
    }
}
