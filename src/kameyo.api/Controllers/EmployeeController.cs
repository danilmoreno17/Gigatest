using Kameyo.Api.Filters;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Employee.Dtos.Request;
using Kameyo.Core.Application.Modules.Employee.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    public class EmployeeController : ApiControllerBase
    {
        public EmployeeController()
        {
            
        }

        [HttpGet("filter")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions)
        {
            var query = new GetEmployeesLoadOptionsQueryRequest() { LoadOptions = loadOptions };
            return BuildResponse(await Mediator.Send(query));
        }


        [HttpGet]
        public async Task<ActionResult<Result<EmployeeDtoResponse>>> Get([FromQuery] GetEmployeeQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<ResultPaginated<EmployeeDtoResponse>>> GetPaginated([FromQuery] GetEmployeePaginationQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateEmployeeCommandRequest createCompanyRequest)
        {
            return BuildResponse(await Mediator.Send(createCompanyRequest));
        }


        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateEmployeeCommandRequest updateCompanyRequest)
        {
            return BuildResponse(await Mediator.Send(updateCompanyRequest));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<string>>> Delete(Guid id)
        {
            return BuildResponse(await Mediator.Send(new DeleteEmployeeCommandRequest() { Id = id }));
        }
    }
}
