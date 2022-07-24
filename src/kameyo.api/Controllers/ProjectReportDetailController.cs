using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectReportActivity.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectReportDetailController : ApiControllerBase
    {
        public ProjectReportDetailController()
        {

        }

        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateProjectActivityCommandRequest updateProjectRequest)
        {
            return BuildResponse(await Mediator.Send(updateProjectRequest));
        }

    }
}
