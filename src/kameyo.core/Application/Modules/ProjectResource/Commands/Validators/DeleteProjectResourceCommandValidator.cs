using FluentValidation;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectResource.Commands.Validators
{
    public class DeleteProjectResourceCommandValidator : AbstractValidator<DeleteProjectResourceCommandRequest>
    {
        public DeleteProjectResourceCommandValidator(/*bool projectTaskExists*/)
        {
            RuleFor(x => x.Id)
              .Must(x => true/*projectTaskExists*/)
              .WithMessage(x => $"El ID no existe");
        }
    }
}
