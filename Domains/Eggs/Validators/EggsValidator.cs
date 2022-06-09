using EggStore.Domains.Eggs.Dto;
using EggStore.Domains.Eggs.Repositories;
using EggStore.Domains.Packages.Repositories;
using EggStore.Infrastucture.Shareds;
using FluentValidation;

namespace EggStore.Domains.Eggs.Validators
{
    public class EggsValidator : BaseValidator<EggsDto>
    {
        private readonly EggsRepository _repositoryEgg;
        private readonly PackagesRepository _repositoryPackage;
        public EggsValidator(
            EggsRepository eggsRepository,
            PackagesRepository packagesRepository)
        {
            _repositoryEgg = eggsRepository;
            _repositoryPackage = packagesRepository;

            When(x => x.Id != default, () =>
            {
                RuleFor(x => x.Id)
                    .Must(CheckExistEgg)
                    .OverridePropertyName("notif")
                    .WithMessage("data not found");
            });

            RuleFor(x => x.EggName)
                .NotEmpty()
                .WithMessage("{PropertyName} " + message);

            RuleFor(x => x.Stok)
                .NotEmpty()
                .WithMessage("{PropertyName} " + message);

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("{PropertyName} " + message);

            RuleFor(x => x.PackageId)
                .Must(CheckExistPackage)
                .OverridePropertyName("notif")
                .WithMessage("invalid selected package Id");
        }

        private bool CheckExistEgg(Guid id)
        {
            return _repositoryEgg.FindById(id) != null;
        }

        private bool CheckExistPackage(Guid id)
        {
            return _repositoryPackage.FindById(id) != null;
        }
    }
}
