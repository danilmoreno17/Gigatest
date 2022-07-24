using FluentValidation;
using Kameyo.Core.Application.Modules.Contact.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Contact.Commands.Validators
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommandRequest>
    {
        public CreateContactCommandValidator()
        {
            //RuleFor(x => x.NumberId)
            //    .Must(x => !ContactExits)
            //    .WithMessage(x => $"La empresa ya existe -> {x.NumberId}");

            RuleFor(x => x.Names)
                .NotEmpty()
                .NotNull()
                .WithMessage("El nombre del Contacto es requerido.");

        }
    }
}
