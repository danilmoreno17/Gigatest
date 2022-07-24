using Kameyo.Api.Filters;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Request;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogsController : ApiControllerBase
    {
        public CatalogsController()
        { 
        
        }

        [HttpGet("filter")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions)
        {
            var query = new GetCatalogsLoadOptionsQueryRequest() { LoadOptions = loadOptions };
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet]
        public async Task<ActionResult<Result<CatalogsDtoResponse>>> Get([FromQuery] GetCatalogQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<ResultPaginated<CatalogsDtoResponse>>> GetPaginated([FromQuery] GetCatalogsPaginationQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateCatalogCommandRequest createCatalogRequest)
        {
            return BuildResponse(await Mediator.Send(createCatalogRequest));
        }


        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateCatalogCommandRequest updateCatalogRequest)
        {
            return BuildResponse(await Mediator.Send(updateCatalogRequest));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(Guid id)
        {
            return BuildResponse(await Mediator.Send(new DeleteCatalogCommandRequest() { Id = id }));
        }
    }
}
