using FluentValidation;
using Kameyo.Core.Application.Modules.Company.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Company.Commands.Validators
{
    public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommandRequest>
    {
        public DeleteCompanyCommandValidator()
        {
            //RuleFor(x => x.Id)
            //    .Must(x => companyExits)
            //    .WithMessage(x => $"El ID no existe");
        }
    }
}
