using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeSkillAbility.Dtos.Request;
using Kameyo.Core.Application.Modules.EmployeeSkillAbility.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSkillAbilitiesController : ApiControllerBase
    {
        public EmployeeSkillAbilitiesController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<Result<EmployeeSkillAbilitiesDtoResponse>>> Get([FromQuery] GetEmployeeSkillAbilityQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateEmployeeSkillAbilityCommandRequest createEmployeeSkillAbility)
        {
            return BuildResponse(await Mediator.Send(createEmployeeSkillAbility));
        }


        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateEmployeeSkillAbilityCommandRequest updateEmployeeSkillAbility)
        {
            return BuildResponse(await Mediator.Send(updateEmployeeSkillAbility));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(Guid id)
        {
            return BuildResponse(await Mediator.Send(new DeleteEmployeeSkillAbilityCommandRequest() { Id = id }));
        }
    }
}
