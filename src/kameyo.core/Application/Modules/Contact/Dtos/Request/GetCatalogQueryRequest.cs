using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Contact.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.Contact.Dtos.Request
{
    public class GetContactQueryRequest : IRequest<Result<ContactDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
