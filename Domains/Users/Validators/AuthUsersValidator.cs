using EggStore.Domains.Users.Dto;
using FluentValidation;

namespace EggStore.Domains.Users.Validators
{
    public class AuthUsersValidator : AbstractValidator<AuthUsersDto>
    {
        public AuthUsersValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
