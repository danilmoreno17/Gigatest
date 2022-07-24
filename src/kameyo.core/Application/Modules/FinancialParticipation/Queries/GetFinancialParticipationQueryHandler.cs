using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Request;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Response;
using Kameyo.Core.Application.Modules.FinancialParticipation.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.FinancialParticipation.Queries
{
    public class GetFinancialParticipationQueryHandler : IRequestHandler<GetFinancialParticipationQueryRequest, Result<FinancialParticipationDtoResponse>>
    {
        private readonly IApplicationDbContext _context;

        private readonly string FILTER_FIELD_NAME = "NAME";

        public GetFinancialParticipationQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<FinancialParticipationDtoResponse>> Handle(GetFinancialParticipationQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var Employee = await _context.FinancialParticipation
                .Include(x=> x.Employee)
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => FinancialParticipationMapping.MapToFinancialParticipationDTO(x))
                .ToListAsync(cancellationToken: cancellationToken);

            if (Employee == null) return Result<FinancialParticipationDtoResponse>.NotFound();

            return Result<FinancialParticipationDtoResponse>.Success(Employee);

        }

        private ISpecification<Domain.Entities.FinancialParticipation> GetSpecification(GetFinancialParticipationQueryRequest request)
        {
            ISpecification<Domain.Entities.FinancialParticipation> specification = new GetFinancialParticipationByIdSepec(request.Value);
            /*
            if (request.Field.ToUpper() == FILTER_FIELD_NAME)
            {
                specification = new GetEmployeeByNameSpec(request.Value);
            }
            if (request.Field.ToUpper() == FILTER_FIELD_PARENTID)
            {
                specification = new GetEmployeeByParentIdSpec(request.Value);
            }
            if (request.Field.ToUpper() == FILTER_FIELD_SUBSIDIARYID)
            {
                specification = new GetEmployeesBySubsidiaryIdSpec(request.Value);
            }
            */
            return specification;
        }
    }
}
