using FluentValidation;
using LuxeLooks.Domain.Models;

public class ReviewRequestValidator : AbstractValidator<ReviewRequest>
{
    public ReviewRequestValidator()
    {
        RuleFor(request => request.UserId).NotEmpty().WithMessage("UserId cannot be empty.");
        RuleFor(request => request.Title).NotEmpty().WithMessage("Title cannot be empty.");
        RuleFor(request => request.ProductId).NotEmpty().WithMessage("ProductId cannot be empty.");
    }
}