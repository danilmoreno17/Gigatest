using Kameyo.Api.Filters;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Request;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubsidiariesController : ApiControllerBase
    {
        public SubsidiariesController()
        {

        }

        [HttpGet("filter")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions)
        {
            var query = new GetSubsidiariesLoadOptionsQueryRequest() { LoadOptions = loadOptions };
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet]
        public async Task<ActionResult<Result<SubsidiariesDtoResponse>>> Get([FromQuery] GetSubsidiaryQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<ResultPaginated<SubsidiariesDtoResponse>>> GetPaginated([FromQuery] GetSubsidiariesPaginationQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateSubsidiaryCommandRequest createSubsidiaryRequest)
        {
            return BuildResponse(await Mediator.Send(createSubsidiaryRequest));
        }

        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateSubsidiaryCommandRequest updateSubsidiaryRequest)
        {
            return BuildResponse(await Mediator.Send(updateSubsidiaryRequest));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(string id)
        {
            return BuildResponse(await Mediator.Send(new DeleteSubsidiaryCommandRequest() { Id = Guid.Parse(id)}));
        }
    }
}
