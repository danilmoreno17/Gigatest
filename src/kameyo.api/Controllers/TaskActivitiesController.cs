using Kameyo.Api.Filters;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Request;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskActivitiesController : ApiControllerBase
    {
        public TaskActivitiesController()
        {

        }
        [HttpGet("filter/{projectTaskId}")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions, Guid? projectTaskId=null)
        {
            var query = new GetTaskActivitiesLoadOptionsQueryRequest() { LoadOptions = loadOptions, ProjectTaskId=projectTaskId };
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet]
        public async Task<ActionResult<Result<TaskActivitiesDtoResponse>>> Get([FromQuery] GetTaskActivityQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<ResultPaginated<TaskActivitiesDtoResponse>>> GetPaginated([FromQuery] GetTaskActivitiesPaginationQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateTaskActivityCommandRequest createTaskActivityRequest)
        {
            return BuildResponse(await Mediator.Send(createTaskActivityRequest));
        }


        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateTaskActivityCommandRequest updateTaskActivityRequest)
        {
            return BuildResponse(await Mediator.Send(updateTaskActivityRequest));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(Guid id)
        {
            return BuildResponse(await Mediator.Send(new DeleteTaskActivityCommandRequest() { Id = id }));
        }
    }
}
