using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.Customer.Dtos.Request
{
    public class GetCustomerQueryRequest : IRequest<Result<CustomerDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
