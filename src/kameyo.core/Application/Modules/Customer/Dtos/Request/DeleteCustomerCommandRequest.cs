using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.Customer.Dtos.Request
{
    public class DeleteCustomerCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; } = default!;
    }
}
