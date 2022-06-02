using EggStore.Domains.Users.Entities;
using FluentValidation;

namespace EggStore.Domains.Users.Validators
{
    public class UsersValidator : AbstractValidator<UsersEntity>
    {
        public UsersValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty();

            RuleFor(x => x.Username)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();

            RuleFor(x => x.Role)
                .NotEmpty();
        }
    }
}
