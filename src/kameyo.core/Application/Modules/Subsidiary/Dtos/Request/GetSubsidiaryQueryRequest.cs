using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.Subsidiary.Dtos.Request
{
    public class GetSubsidiaryQueryRequest : IRequest<Result<SubsidiariesDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
