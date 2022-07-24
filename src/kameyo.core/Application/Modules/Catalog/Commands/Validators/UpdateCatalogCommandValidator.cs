using FluentValidation;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Catalog.Commands.Validators
{
    public class UpdateCatalogCommandValidator : AbstractValidator<UpdateCatalogCommandRequest>
    {
        public UpdateCatalogCommandValidator()
        {
            //RuleFor(x => x.Id)
            //    .Must(x => companyExists)
            //    .WithMessage(x => $"El ID no existe");
        }
    }
}
