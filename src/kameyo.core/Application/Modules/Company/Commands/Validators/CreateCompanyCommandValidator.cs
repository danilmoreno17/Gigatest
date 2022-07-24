using FluentValidation;
using Kameyo.Core.Application.Modules.Company.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Company.Commands.Validators
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommandRequest>
    {
        public CreateCompanyCommandValidator()
        {
            //RuleFor(x => x.NumberId)
            //    .Must(x => !companyExits)
            //    .WithMessage(x => $"La empresa ya existe -> {x.NumberId}");

            RuleFor(x => x.NumberId)
                .NotEmpty()
                .NotNull()
                .WithMessage("El numero de empresa es requerido.");

        }
    }
}
