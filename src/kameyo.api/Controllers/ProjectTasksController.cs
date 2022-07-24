using Kameyo.Api.Filters;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTasksController : ApiControllerBase
    {
        public ProjectTasksController()
        {

        }

        [HttpGet("filter")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions)
        {
            var query = new GetProjectTasksLoadOptionsQueryRequest() { LoadOptions = loadOptions };
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet]
        public async Task<ActionResult<Result<ProjectTasksDtoResponse>>> Get([FromQuery] GetProjectTaskQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<ResultPaginated<ProjectTasksDtoResponse>>> GetPaginated([FromQuery] GetProjectTasksPaginationQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateProjectTaskCommandRequest createProjectRequest)
        {
            return BuildResponse(await Mediator.Send(createProjectRequest));
        }


        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateProjectTaskCommandRequest updateProjectRequest)
        {
            return BuildResponse(await Mediator.Send(updateProjectRequest));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(Guid id)
        {
            return BuildResponse(await Mediator.Send(new DeleteProjectTaskCommandRequest() { Id = id }));
        }
    }
}
