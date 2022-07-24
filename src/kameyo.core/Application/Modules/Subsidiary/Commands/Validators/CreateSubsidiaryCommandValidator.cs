using FluentValidation;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Subsidiary.Commands.Validators
{
    public class CreateSubsidiaryCommandValidator : AbstractValidator<CreateSubsidiaryCommandRequest>
    {
        public CreateSubsidiaryCommandValidator(/*Boolean subsidiaryExists*/) 
        {
            RuleFor(x => x.NumberId)
               .Must(x => /*!subsidiaryExists*/true)
               .WithMessage(x => $"El número de la filial ya existe. No: -> {x.NumberId}");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El nombre es requerido.")
                .EmailAddress()
                .WithMessage("Un nombre valido es requerido.");
        }
    }
}
