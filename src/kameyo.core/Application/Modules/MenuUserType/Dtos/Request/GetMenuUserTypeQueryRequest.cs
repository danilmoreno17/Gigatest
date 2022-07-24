using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.MenuUserType.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.MenuUserType.Dtos.Request
{
    public class GetMenuUserTypeQueryRequest : IRequest<Result<GetMenuUserTypeQueryResponse>>
    {
        public Guid roleId { get; set; }
    }
}
