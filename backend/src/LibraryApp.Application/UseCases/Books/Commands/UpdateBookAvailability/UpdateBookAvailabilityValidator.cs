using FluentValidation;

namespace LibraryApp.Application.UseCases.Books.Commands.UpdateBookAvailability;

public sealed class UpdateBookAvailabilityValidator : AbstractValidator<UpdateBookAvailabilityCommand>
{
    public UpdateBookAvailabilityValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
