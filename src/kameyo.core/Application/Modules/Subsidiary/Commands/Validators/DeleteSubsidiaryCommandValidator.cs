using FluentValidation;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Subsidiary.Commands.Validators
{
    public class DeleteSubsidiaryCommandValidator : AbstractValidator<DeleteSubsidiaryCommandRequest>
    {
        public DeleteSubsidiaryCommandValidator(/*Boolean subsidiaryExists*/)
        {
            RuleFor(x => x.Id)
              .Must(x => true/*subsidiaryExists*/)
              .WithMessage(x => $"El ID no existe");
        }
    }
}
