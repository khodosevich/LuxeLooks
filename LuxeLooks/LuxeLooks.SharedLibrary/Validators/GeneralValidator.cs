using System.Text;
using FluentValidation;

namespace LuxeLooks.SharedLibrary.Validators;

public static class GeneralValidator
{
    public static StringBuilder Validate<T>(AbstractValidator<T> validator, T model)
    {
        var validateResult = validator.ValidateAsync(model).Result;
        if (!validateResult.IsValid)
        {
            var errors =new StringBuilder();
            validateResult.Errors.ForEach(a => errors.Append(a.ErrorMessage).Append("\n"));
            return errors;
        }
        return new StringBuilder();
    }
}