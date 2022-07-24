using FluentValidation;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Catalog.Commands.Validators
{
    public class DeleteCatalogCommandValidator : AbstractValidator<DeleteCatalogCommandRequest>
    {
        public DeleteCatalogCommandValidator()
        {
            //RuleFor(x => x.Id)
            //    .Must(x => companyExits)
            //    .WithMessage(x => $"El ID no existe");
        }
    }
}
