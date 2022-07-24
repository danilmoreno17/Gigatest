using Ardalis.Specification;
using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Employee.Dtos.Request;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Request;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Response;
using Kameyo.Core.Application.Modules.FinancialParticipation.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.FinancialParticipation.Queries
{
    public class GetFinancialParticipationLoadOptionsQueryHandler : IRequestHandler<GetFinancialParticipationLoadOptionsQueryRequest, LoadResultModel>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly string FILTER_FIELD_NAME = "NAME";
        public GetFinancialParticipationLoadOptionsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LoadResultModel> Handle(GetFinancialParticipationLoadOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            request.LoadOptions ??= new DataSourceLoadOptionsBase();
            request.LoadOptions.PrimaryKey = new string[] { "Id" };

            var employees = _dbContext.FinancialParticipation
                .Include(x => x.Employee)
                .Where(x => x.Active)
                .AsNoTracking();


            var loadResultResponse = await DataSourceLoader.LoadAsync(employees, request.LoadOptions, cancellationToken);
            loadResultResponse.data = ((IList<Domain.Entities.Employee>)loadResultResponse.data).MapToEmployeesDTO();

            return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK); ;
        }
        /*
        private ISpecification<Domain.Entities.FinancialParticipation> GetSpecification(GetFinancialParticipationLoadOptionsQueryRequest request)
        {
            ISpecification<Domain.Entities.ProjectReport> specification = new GetProjectReportByIdSepec(request.Value);

            if (request.Field.ToUpper() == FILTER_FIELD_NAME)
            {
                specification = new GetFinancialParticipationByIdSepec(request.Value);
            }
            return specification;
        }
        */
    }
}
