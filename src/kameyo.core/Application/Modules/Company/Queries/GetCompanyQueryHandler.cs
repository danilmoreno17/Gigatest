using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Company.Dtos.Request;
using Kameyo.Core.Application.Modules.Company.Dtos.Response;
using Kameyo.Core.Application.Modules.Company.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.Company.Queries
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQueryRequest, Result<CompanyDtoResponse>>
    {
        private readonly IApplicationDbContext _context;

        private readonly string FILTER_FIELD_NAME = "NAME";
        private readonly string FILTER_FIELD_NUMBERID = "NUMBERID";
        private readonly string FILTER_FIELD_ID = "ID";

        public GetCompanyQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<CompanyDtoResponse>> Handle(GetCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var company = await _context.Companies
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => CompanyMapping.MapToCompanyDTO(x))
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (company == null) return Result<CompanyDtoResponse>.NotFound();

            return Result<CompanyDtoResponse>.Success(new List<CompanyDtoResponse>() { company });
        }

        private ISpecification<Domain.Entities.Company> GetSpecification(GetCompanyQueryRequest request)
        {
            ISpecification<Domain.Entities.Company> specification = new GetCompanyByIdSpec(request.Value);

            if (request.Field.ToUpper() == FILTER_FIELD_NAME)
            {
                specification = new GetCompanyByNameSpec(request.Value);
            }

            if (request.Field.ToUpper() == FILTER_FIELD_NUMBERID)
            {
                specification = new GetCompanyByNumerIdSpec(request.Value);
            }
            return specification;
        }
    }
}
