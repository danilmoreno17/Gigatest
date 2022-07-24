using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.MenuUserType.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.MenuUserType.Dtos.Request
{
    public class GetMenuQueryRequest : IRequest<Result<GetMenuQueryResponse>>
    {
        public GetMenuQueryRequest()
        {

        }        
        public string UserEmail { get; set; }
    }
}
