using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Response;
using Kameyo.Api.Filters;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectReportController : ApiControllerBase
    {
        public ProjectReportController()
        {

        }

        [HttpGet("generator/{customerId}/{year}/{month}")]
        public async Task<ActionResult<Result<ProjectReportGeneratorResponse>>> Get(Guid customerId, int year, int month)
        {
            var query = new ProjectReportGeneratorRequest() { CustomerId = customerId, Year = year, Month = month};
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("byprojectmanager/{employeeId}/{year}/{month}")]
        public async Task<ActionResult<Result<ProjectReportDtoResponse>>> GetByProjectManager(Guid employeeId, int year, int month)
        {
            var query = new GetProjectReportByProjectManagerRequest() { EmployeeId =employeeId, Year = year, Month=month };
            return BuildResponse(await Mediator.Send(query));
        }



        [HttpGet]
        public async Task<ActionResult<Result<ProjectReportDtoResponse>>> Get([FromQuery] GetProjectReportQueryRequest query)
        {
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


        [HttpGet("filter/bycustomer/{customerId}/{year}/{month}")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptionsByCustomer(DataSourceLoadOptions loadOptions, Guid customerId, int year, int month)
        {
            var query = new GetProjectsReportLoadOptionsQueryRequest() { LoadOptions = loadOptions, CustomerId = customerId, Year=year, Month=month };
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateProjectReportCommandRequest updateProjectRequest)
        {
            return BuildResponse(await Mediator.Send(updateProjectRequest));
        }
    }
}
