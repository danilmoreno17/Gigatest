using Kameyo.Api.Filters;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagersController : ApiControllerBase
    {
        public ProjectManagersController()
        {

        }

        [HttpGet("filter")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions)
        {
            var query = new GetProjectManagersLoadOptionsQueryRequest() { LoadOptions = loadOptions };
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet]
        public async Task<ActionResult<Result<ProjectManagersDtoResponse>>> Get([FromQuery] GetProjectManagerQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<ResultPaginated<ProjectManagersDtoResponse>>> GetPaginated([FromQuery] GetProjectManagersPaginationQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateProjectManagerCommandRequest createProjectRequest)
        {
            return BuildResponse(await Mediator.Send(createProjectRequest));
        }


        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateProjectManagerCommandRequest updateProjectRequest)
        {
            return BuildResponse(await Mediator.Send(updateProjectRequest));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(Guid id)
        {
            return BuildResponse(await Mediator.Send(new DeleteProjectManagerCommandRequest() { Id = id }));
        }
    }
}
