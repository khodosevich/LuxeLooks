using FluentValidation;
using LuxeLooks.Domain.Models.Requests;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");

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