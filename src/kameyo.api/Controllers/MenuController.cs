using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.MenuUserType.Dtos.Request;
using Kameyo.Core.Application.Modules.MenuUserType.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ApiControllerBase
    {
        public MenuController()
        {
        }

        [HttpGet]
        public async Task<ActionResult<Result<GetMenuQueryResponse>>> Get([FromQuery] GetMenuQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("role")]
        public async Task<ActionResult<Result<GetMenuUserTypeQueryResponse>>> GetMenuRol([FromQuery] GetMenuUserTypeQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPut("role")]
        public async Task<ActionResult<Result<LoadResultModel>>> UpdateUserRolesByUserId(UpdateMenuRolSelectedCommandRequest request)
        {
            return BuildResponse(await Mediator.Send(request));
        }
    }
}
