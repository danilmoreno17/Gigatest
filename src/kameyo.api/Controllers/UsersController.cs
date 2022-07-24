using Kameyo.Api.Filters;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;
using Kameyo.Infrastructure.Identity.User.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        public UsersController()
        {

        }

        [HttpGet()]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions)
        {
            var query = new GetUsersLoadOptionsQueryRequest() { LoadOptions = loadOptions };
            return BuildResponse(await Mediator.Send(query));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Result<UsersResponse>>> GetById(Guid id)
        {
            return BuildResponse(await Mediator.Send(new GetUserQueryRequest() { Field = "ID", Value = id.ToString() }));
        }

        [HttpGet("{id}/roles")]
        public async Task<ActionResult<Result<LoadResultModel>>> GetUserRolesByUserId(Guid id)
        {
            return BuildResponse(await Mediator.Send(new GetUserRolesSelectQueryRequest() {  UserId = id }));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateUserCommandRequest createUserRequest)
        {
            return BuildResponse(await Mediator.Send(createUserRequest));
        }        

        [HttpPut("{id}/roles")]
        public async Task<ActionResult<Result<LoadResultModel>>> UpdateUserRolesByUserId(UpdateUserRolesSelectCommandRequest request)
        {
            return BuildResponse(await Mediator.Send(request));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateUserCommandRequest updateUserRequest, Guid id)
        {
            updateUserRequest.Id = id;
            return BuildResponse(await Mediator.Send(updateUserRequest));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(string id)
        {
            return BuildResponse(await Mediator.Send(new DeleteUserCommandRequest() { Id = id }));
        }
    }
}
