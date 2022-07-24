using Kameyo.Api.Filters;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Customer.Dtos;
using Kameyo.Core.Application.Modules.Customer.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ApiControllerBase
    {
        public CustomerController()
        {

        }

        [HttpGet("filter")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions)
        {
            var query = new GetCustomersLoadOptionsQueryRequest() { LoadOptions = loadOptions };
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet]
        public async Task<ActionResult<Result<CustomerDtoResponse>>> Get([FromQuery] GetCustomerQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<ResultPaginated<CustomerDtoResponse>>> GetPaginated([FromQuery] GetCustomerPaginationQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateCustomerCommandRequest createCompanyRequest)
        {
            return BuildResponse(await Mediator.Send(createCompanyRequest));
        }


        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateCustomerCommandRequest updateCompanyRequest)
        {
            return BuildResponse(await Mediator.Send(updateCompanyRequest));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(Guid id)
        {
            return BuildResponse(await Mediator.Send(new DeleteCustomerCommandRequest() { Id = id }));
        }

    }
}
