using Kameyo.Api.Filters;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Request;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialParticipationController : ApiControllerBase
    {
        public FinancialParticipationController()
        {

        }
        [HttpGet]
        public async Task<ActionResult<Result<FinancialParticipationDtoResponse>>> Get([FromQuery] GetFinancialParticipationQueryRequest query)
        {
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("taskActivitiesDetails/filter/{employeeId}/{year}/{month}")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptionsTaskActivitiesDetails(DataSourceLoadOptions loadOptions, Guid employeeId, int year, int month)
        {
            var query = new GetFinancialParticipationDetailsLoadOptionsQueryRequest() { LoadOptions = loadOptions, Year = year, Month = month, EmployeeId= employeeId};
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("filter")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions)
        {
            var query = new GetFinancialParticipationLoadOptionsQueryRequest() { LoadOptions = loadOptions };
            return BuildResponse(await Mediator.Send(query));
        }
        [HttpGet("filter/{employeeId}/{year}/{month}")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions, Guid employeeId, int year, int month)
        {
            var query = new FinancialParticipationGeneralLoadOptionRequest() { LoadOptions = loadOptions, EmployeeId = employeeId, Year = year, Month = month, Type = ' ' };
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpGet("{employeeId}/{year}/{month}")]
        public async Task<ActionResult<Result<FinancialParticipationDtoResponse>>> Get(Guid employeeId, int year, int month)
        {
            var query = new FinancialParticipationGeneralRequest() { EmployeeId = employeeId, Year = year, Month = month, Type = ' ' };
            return BuildResponse(await Mediator.Send(query));
        }
        [HttpGet("filter/discretionary/{employeeId}/{year}/{month}")]
        public async Task<ActionResult<LoadResultModel>> GetLoadOptionsDiscretionary(DataSourceLoadOptions loadOptions, Guid employeeId, int year, int month)
        {
            var query = new FinancialParticipationGeneralLoadOptionRequest() { LoadOptions = loadOptions, EmployeeId = employeeId, Year = year, Month = month, Type = 'A' };
            return BuildResponse(await Mediator.Send(query));
        }
        [HttpGet("discretionary/{employeeId}/{year}/{month}")]
        public async Task<ActionResult<Result<FinancialParticipationDtoResponse>>> GetDiscretionary(Guid employeeId, int year, int month)
        {
            var query = new FinancialParticipationGeneralRequest() { EmployeeId = employeeId, Year = year, Month = month, Type= 'A' };
            return BuildResponse(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Result<string>>> Post([FromBody] CreateFinancialParticipationCommandRequest createProjectRequest)
        {
            return BuildResponse(await Mediator.Send(createProjectRequest));
        }


        [HttpPut()]
        public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateFinancialParticipationCommandRequest updateProjectRequest)
        {
            return BuildResponse(await Mediator.Send(updateProjectRequest));
        }


    }
}
