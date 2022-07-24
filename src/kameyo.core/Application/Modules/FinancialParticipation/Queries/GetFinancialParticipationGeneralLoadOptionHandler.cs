using Ardalis.Specification;

using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Request;
using Kameyo.Core.Application.Common.Mappings;

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;



namespace Kameyo.Core.Application.Modules.ProjectReport.Queries
{
    public class GetFinancialParticipationGeneralLoadOptionHandler :IRequestHandler<FinancialParticipationGeneralLoadOptionRequest, LoadResultModel>
    {
        private readonly IApplicationDbContext _context;

        private readonly string FILTER_FIELD_NAME = "NAME";
        public GetFinancialParticipationGeneralLoadOptionHandler(IApplicationDbContext context)
        {
            this._context= context;
        }



        public async Task<LoadResultModel> Handle(FinancialParticipationGeneralLoadOptionRequest request, CancellationToken cancellationToken)
        {
            request.LoadOptions ??= new DataSourceLoadOptionsBase();
            request.LoadOptions.PrimaryKey = new string[] { "Id" };

            if (request.Type == 'A')
            {
                //var specification = GetSpecification(request);
                var financialParticipation = _context.FinancialParticipation
                    .Include(x => x.Employee)
                   .Where(x => x.Active && x.Type == request.Type && x.EmployeeId == request.EmployeeId && x.Year == request.Year && x.Month == request.Month )
                   .AsNoTracking();

                var loadResultResponse = await DataSourceLoader.LoadAsync(financialParticipation, request.LoadOptions, cancellationToken);
                loadResultResponse.data = ((IList<Domain.Entities.FinancialParticipation>)loadResultResponse.data).MapToFinancialParticipationDTO();

                return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK);
            }
            else
            {
                var financialParticipation = _context.FinancialParticipation
                    .Include(x => x.Employee)
                    .Where(x => x.Active && x.EmployeeId == request.EmployeeId && x.Year == request.Year && x.Month == request.Month)
                    .AsNoTracking();

                var loadResultResponse = await DataSourceLoader.LoadAsync(financialParticipation, request.LoadOptions, cancellationToken);
                loadResultResponse.data = ((IList<Domain.Entities.FinancialParticipation>)loadResultResponse.data).MapToFinancialParticipationDTO();

                return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK);
            }
        }

        /*
        private ISpecification<Domain.Entities.FinancialParticipation> GetSpecification(FinancialParticipationGeneralRequest request)
        {
            ISpecification<Domain.Entities.ProjectReport> specification = new GetProjectReportByIdSepec(request.Value);

            if (request.Field.ToUpper() == FILTER_FIELD_NAME)
            {
                specification = new GetProjectReportByIdSepec(request.Value);
            }
            return specification;
        }
        */
    }
}
