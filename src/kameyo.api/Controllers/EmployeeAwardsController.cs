using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeAward.Dtos.Request;
using Kameyo.Core.Application.Modules.EmployeeAward.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAwardsController : ApiControllerBase
    {
        public EmployeeAwardsController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<Result<EmployeeAwardDtoResponse>>> Get([FromQuery] GetEmployeeAwardQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateEmployeeAwardCommandRequest createEmployeeAward)
        {
            return BuildResponse(await Mediator.Send(createEmployeeAward));
        }


        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateEmployeeAwardCommandRequest updateEmployeeAward)
        {
            return BuildResponse(await Mediator.Send(updateEmployeeAward));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(Guid id)
        {
            return BuildResponse(await Mediator.Send(new DeleteEmployeeAwardCommandRequest() { Id = id }));
        }
    }
}
