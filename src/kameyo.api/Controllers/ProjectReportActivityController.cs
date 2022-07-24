using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectReportActivity.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectReportActivity.Dtos.Request;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectReportActivityController : ApiControllerBase
    {
        public ProjectReportActivityController()
        {

        }



        [HttpGet]
        [HttpGet("activityControl/{projectReportId}/")]
        public async Task<ActionResult<Result<ProjectReportActivityControlResponse>>> Get(Guid projectReportId)
        {
            var query = new ProjectReportActivityControlRequest() { ProjectId = projectReportId };
            return BuildResponse(await Mediator.Send(query));
        }

        /*
        [HttpGet("details/{projectId}/")]
        public async Task<ActionResult<Result<ProjectReportDtoResponse>>> Get(Guid projectId)
        {
            var query = new ProjectReportDetailsRequest() { Id = projectId };
            return BuildResponse(await Mediator.Send(query));
        }
        */



        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateProjectReportRequest createProjectReportRequest)
        {
            return BuildResponse(await Mediator.Send(createProjectReportRequest));
        }


   

    }
}
