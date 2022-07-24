using FluentValidation;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Catalog.Commands.Validators
{
    public class CreateCatalogCommandValidator : AbstractValidator<CreateCatalogCommandRequest>
    {
        public CreateCatalogCommandValidator()
        {
            //RuleFor(x => x.NumberId)
            //    .Must(x => !CatalogExits)
            //    .WithMessage(x => $"La empresa ya existe -> {x.NumberId}");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("El nombre del catalogo es requerido.");

        }
    }
}
