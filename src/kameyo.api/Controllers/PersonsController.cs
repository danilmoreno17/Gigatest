using Kameyo.Api.Filters;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Person.Dtos;
using Kameyo.Core.Application.Modules.Person.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ApiControllerBase
    {
        [HttpGet("types")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions)
        {
            var query = new GetPersonTypeLoadOptionsQueryRequest() { LoadOptions = loadOptions };
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("lookup")]
        public async Task<ActionResult<LoadResultModel>> GetPersonLookUpType(DataSourceLoadOptions loadOptions)
        {
            var query = new GetPersonLookUpLoadOptionsQueryRequest() { LoadOptions = loadOptions };
            return BuildResponse(await Mediator.Send(query));
        }


    }
}
