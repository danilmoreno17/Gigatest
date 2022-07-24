using FluentValidation;
using Kameyo.Core.Application.Modules.Customer.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Customer.Commands.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommandRequest>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.NumberId)
                .NotEmpty()
                .NotNull()
                .WithMessage("El numero de cliente es requerido.");
        }
    }
}
