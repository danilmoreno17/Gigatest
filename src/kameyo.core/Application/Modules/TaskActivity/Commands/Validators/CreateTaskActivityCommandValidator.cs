using FluentValidation;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.TaskActivity.Commands.Validators
{
    public class CreateTaskActivityCommandValidator : AbstractValidator<CreateTaskActivityCommandRequest>
    {
        public CreateTaskActivityCommandValidator(/*bool projectTaskExists*/)
        {
            RuleFor(x => x.Description)
               .Must(x => true/*projectTaskExists*/)
               .WithMessage(x => $"La descripcion {x.Description} ya existe.");
        }
    }
}
