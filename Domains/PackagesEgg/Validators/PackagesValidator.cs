using EggStore.Domains.Packages.Entities;
using FluentValidation;

namespace EggStore.Domains.Packages.Validators
{
    public class PackagesValidator : AbstractValidator<PackagesEntity>
    {
        public PackagesValidator()
        {
            RuleFor(x => x.PackageName)
                .NotEmpty();
        }
    }
}
