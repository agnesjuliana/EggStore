using EggStore.Domains.Packages.Dto;
using EggStore.Infrastucture.Shareds;
using FluentValidation;

namespace EggStore.Domains.Packages.Validators
{
    public class PackagesValidator : BaseValidator<PackagesDto>
    {
        public PackagesValidator()
        {
            RuleFor(x => x.PackageName)
                .NotEmpty()
                .WithMessage("{PropertyName} " + message);
        }
    }
}
