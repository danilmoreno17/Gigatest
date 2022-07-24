using FluentValidation;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectTask.Commands.Validators
{
    public class DeleteProjectTaskCommandValidator : AbstractValidator<DeleteProjectTaskCommandRequest>
    {
        public DeleteProjectTaskCommandValidator(/*bool projectTaskExists*/)
        {
            RuleFor(x => x.Id)
              .Must(x => true/*projectTaskExists*/)
              .WithMessage(x => $"El ID no existe");
        }
    }
}
