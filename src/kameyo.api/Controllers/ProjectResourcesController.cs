using Kameyo.Api.Filters;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectResourcesController : ApiControllerBase
    {
        public ProjectResourcesController()
        {

        }

        [HttpGet("filter")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions)
        {
            var query = new GetProjectResourcesLoadOptionsQueryRequest() { LoadOptions = loadOptions };
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet]
        public async Task<ActionResult<Result<ProjectResourcesDtoResponse>>> Get([FromQuery] GetProjectResourceQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<ResultPaginated<ProjectResourcesDtoResponse>>> GetPaginated([FromQuery] GetProjectResourcesPaginationQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateProjectResourceCommandRequest createProjectRequest)
        {
            return BuildResponse(await Mediator.Send(createProjectRequest));
        }


        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateProjectResourceCommandRequest updateProjectRequest)
        {
            return BuildResponse(await Mediator.Send(updateProjectRequest));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(Guid id)
        {
            return BuildResponse(await Mediator.Send(new DeleteProjectResourceCommandRequest() { Id = id }));
        }
    }
}
