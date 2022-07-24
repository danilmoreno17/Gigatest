using Kameyo.Api.Filters;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.HourBank.Dtos.Request;
using Kameyo.Core.Application.Modules.HourBank.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HourBanksController : ApiControllerBase
    {
        public HourBanksController()
        {

        }

        [HttpGet("filter")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions)
        {
            var query = new GetHourBanksLoadOptionsQueryRequest() { LoadOptions = loadOptions };
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet]
        public async Task<ActionResult<Result<HourBanksDtoResponse>>> Get([FromQuery] GetHourBankQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<ResultPaginated<HourBanksDtoResponse>>> GetPaginated([FromQuery] GetHourBanksPaginationQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateHourBankCommandRequest createHourBankRequest)
        {
            return BuildResponse(await Mediator.Send(createHourBankRequest));
        }

        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateHourBankCommandRequest updateHourBankRequest)
        {
            return BuildResponse(await Mediator.Send(updateHourBankRequest));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(string id)
        {
            return BuildResponse(await Mediator.Send(new DeleteHourBankCommandRequest() { Id = Guid.Parse(id) }));
        }
    }
}
