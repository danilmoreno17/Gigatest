using Kameyo.Api.Filters;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ApiControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions)
        {
            var query = new GetRolesLoadOptionsQueryRequest() { LoadOptions = loadOptions };
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateRoleCommandRequest createRoleRequest)
        {
            return BuildResponse(await Mediator.Send(createRoleRequest));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateRoleCommandRequest updateRoleRequest, Guid id)
        {
            updateRoleRequest.Id = id;
            return BuildResponse(await Mediator.Send(updateRoleRequest));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(string id)
        {
            return BuildResponse(await Mediator.Send(new DeleteRoleCommandRequest() { Id = id }));
        }

    }
}
