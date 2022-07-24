using FluentValidation;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.TaskActivity.Commands.Validators
{
    public class DeleteTaskActivityCommandValidator : AbstractValidator<DeleteTaskActivityCommandRequest>
    {
        public DeleteTaskActivityCommandValidator(/*bool projectTaskExists*/)
        {
            RuleFor(x => x.Id)
              .Must(x => true/*projectTaskExists*/)
              .WithMessage(x => $"El ID no existe");
        }
    }
}
