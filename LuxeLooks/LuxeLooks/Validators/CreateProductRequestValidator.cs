using FluentValidation;
using LuxeLooks.Domain.Models;

using FluentValidation;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Price)
            .NotNull().WithMessage("Price is required")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be non-negative");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required");

        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Type is required");

        RuleFor(x => x.IsForMen)
            .NotNull().WithMessage("IsForMen is required");

        RuleFor(x => x.IsForKids)
            .NotNull().WithMessage("IsForKids is required");
    }
}
