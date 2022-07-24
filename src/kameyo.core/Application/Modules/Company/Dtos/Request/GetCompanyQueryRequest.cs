using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Company.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.Company.Dtos.Request
{
    public class GetCompanyQueryRequest : IRequest<Result<CompanyDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
