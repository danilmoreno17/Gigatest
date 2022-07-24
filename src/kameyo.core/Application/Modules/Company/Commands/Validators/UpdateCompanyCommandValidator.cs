using FluentValidation;
using Kameyo.Core.Application.Modules.Company.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Company.Commands.Validators
{
    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommandRequest>
    {
        public UpdateCompanyCommandValidator()
        {
            //RuleFor(x => x.Id)
            //    .Must(x => companyExists)
            //    .WithMessage(x => $"El ID no existe");
        }
    }
}
