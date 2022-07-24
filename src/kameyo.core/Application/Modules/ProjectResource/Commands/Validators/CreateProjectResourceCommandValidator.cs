using FluentValidation;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectResource.Commands.Validators
{
    public class CreateProjectResourceCommandValidator : AbstractValidator<CreateProjectResourceCommandRequest>
    {
        public CreateProjectResourceCommandValidator(/*bool projectTaskExists*/)
        {
            RuleFor(x => x.EmployeeId)
               .Must(x => true/*projectTaskExists*/)
               .WithMessage(x => $"El nombre {x.EmployeeId} ya existe.");
        }
    }
}
