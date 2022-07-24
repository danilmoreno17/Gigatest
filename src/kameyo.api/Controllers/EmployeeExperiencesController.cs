using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeExperience.Dtos.Request;
using Kameyo.Core.Application.Modules.EmployeeExperience.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeExperiencesController : ApiControllerBase
    {
        public EmployeeExperiencesController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<Result<EmployeeExperiencesDtoResponse>>> Get([FromQuery] GetEmployeeExperienceQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateEmployeeExperienceCommandRequest createEmployeeExperience)
        {
            return BuildResponse(await Mediator.Send(createEmployeeExperience));
        }


        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateEmployeeExperienceCommandRequest updateEmployeeExperience)
        {
            return BuildResponse(await Mediator.Send(updateEmployeeExperience));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(Guid id)
        {
            return BuildResponse(await Mediator.Send(new DeleteEmployeeExperienceCommandRequest() { Id = id }));
        }
    }
}
