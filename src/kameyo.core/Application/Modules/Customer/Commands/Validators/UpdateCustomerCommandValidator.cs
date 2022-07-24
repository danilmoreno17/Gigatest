using FluentValidation;
using Kameyo.Core.Application.Modules.Customer.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Customer.Commands.Validators
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommandRequest>
    {
        public UpdateCustomerCommandValidator()
        {

        }
    }
}
