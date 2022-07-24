using FluentValidation;
using Kameyo.Core.Application.Modules.Contact.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Contact.Commands.Validators
{
    public class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommandRequest>
    {
        public DeleteContactCommandValidator()
        {
            //RuleFor(x => x.Id)
            //    .Must(x => companyExits)
            //    .WithMessage(x => $"El ID no existe");
        }
    }
}
