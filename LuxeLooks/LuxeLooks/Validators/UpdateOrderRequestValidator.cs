using FluentValidation;
using LuxeLooks.Domain.Models.Requests;

namespace LuxeLooks.Validators;

public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
{
    public UpdateOrderRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address");

        RuleFor(x => x.ProductsIds)
            .Must(list => list != null && list.Count > 0).WithMessage("At least one product is required");
    }
}