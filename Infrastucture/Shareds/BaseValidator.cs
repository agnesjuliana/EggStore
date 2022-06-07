using FluentValidation;
using FluentValidation.Results;

namespace EggStore.Infrastucture.Shareds
{
    public class BaseValidator<T> : AbstractValidator<T>
    {
        protected const string message = "must be required";
        protected const string messageEnum = "must be valid value";

        protected override bool PreValidate(ValidationContext<T> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("notif", "Invalid Data Request"));
                return false;
            }
            return true;
        }
    }
}
