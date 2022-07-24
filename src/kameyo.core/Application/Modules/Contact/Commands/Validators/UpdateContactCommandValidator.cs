using FluentValidation;
using Kameyo.Core.Application.Modules.Contact.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Contact.Commands.Validators
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommandRequest>
    {
        public UpdateContactCommandValidator()
        {
            //RuleFor(x => x.Id)
            //    .Must(x => companyExists)
            //    .WithMessage(x => $"El ID no existe");
        }
    }
}
