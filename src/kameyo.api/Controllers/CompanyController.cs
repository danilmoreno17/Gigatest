using Kameyo.Api.Filters;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Company.Dtos.Request;
using Kameyo.Core.Application.Modules.Company.Dtos.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kameyo.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ApiControllerBase
	{
		public CompanyController()
		{

		}

		[HttpGet("filter")]
		public async Task<ActionResult<LoadResultModel>> GetLoadOptions(DataSourceLoadOptions loadOptions)
		{
			var query = new GetCompaniesLoadOptionsQueryRequest() { LoadOptions = loadOptions };
			return BuildResponse(await Mediator.Send(query));
		}

		[HttpGet]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, /*Roles = "Administrator"*/  Policy = "")]
		public async Task<ActionResult<Result<CompanyDtoResponse>>> Get([FromQuery] GetCompanyQueryRequest query)
		{
			return BuildResponse(await Mediator.Send(query));
		}

		[HttpGet("paginated")]
		//[Authorize(Policy = "PaginatedOnly")]
		public async Task<ActionResult<ResultPaginated<CompanyDtoResponse>>> GetPaginated([FromQuery] GetCompanyPaginationQueryRequest query)
		{
			return BuildResponse(await Mediator.Send(query));
		}

		[HttpPost]
		public async Task<ActionResult<Result<string>>> Post([FromBody] CreateCompanyCommandRequest createCompanyRequest)
		{
			return BuildResponse(await Mediator.Send(createCompanyRequest));
		}


		[HttpPut()]
		public async Task<ActionResult<Result<string>>> Put([FromBody] UpdateCompanyCommandRequest updateCompanyRequest)
		{
			return BuildResponse(await Mediator.Send(updateCompanyRequest));
		}


		[HttpDelete("{id}")]
		public async Task<ActionResult<Result<string>>> Delete(Guid id)
		{
			return BuildResponse(await Mediator.Send(new DeleteCompanyCommandRequest() { Id = id }));
		}
	}
}
