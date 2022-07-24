using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeCertification.Dtos.Request;
using Kameyo.Core.Application.Modules.EmployeeCertification.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCertificationsController : ApiControllerBase
    {
        public EmployeeCertificationsController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<Result<EmployeeCertificationsDtoResponse>>> Get([FromQuery] GetEmployeeCertificationQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateEmployeeCertificationCommandRequest createEmployeeCertification)
        {
            return BuildResponse(await Mediator.Send(createEmployeeCertification));
        }


        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateEmployeeCertificationCommandRequest updateEmployeeCertification)
        {
            return BuildResponse(await Mediator.Send(updateEmployeeCertification));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(Guid id)
        {
            return BuildResponse(await Mediator.Send(new DeleteEmployeeCertificationCommandRequest() { Id = id }));
        }
    }
}
