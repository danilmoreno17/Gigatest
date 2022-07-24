using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeStudy.Dtos.Request;
using Kameyo.Core.Application.Modules.EmployeeStudy.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeStudiesController : ApiControllerBase
    {
        public EmployeeStudiesController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<Result<EmployeeStudiesDtoResponse>>> Get([FromQuery] GetEmployeeStudyQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateEmployeeStudyCommandRequest createEmployeeStudy)
        {
            return BuildResponse(await Mediator.Send(createEmployeeStudy));
        }


        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateEmployeeStudyCommandRequest updateEmployeeStudy)
        {
            return BuildResponse(await Mediator.Send(updateEmployeeStudy));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(Guid id)
        {
            return BuildResponse(await Mediator.Send(new DeleteEmployeeStudyCommandRequest() { Id = id }));
        }
    }
}
