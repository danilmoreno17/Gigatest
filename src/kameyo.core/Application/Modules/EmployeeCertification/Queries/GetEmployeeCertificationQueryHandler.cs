using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeCertification.Dtos.Request;
using Kameyo.Core.Application.Modules.EmployeeCertification.Dtos.Response;
using Kameyo.Core.Application.Modules.EmployeeCertification.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.EmployeeCertification.Queries
{
    public class GetEmployeeCertificationQueryHandler : IRequestHandler<GetEmployeeCertificationQueryRequest, Result<EmployeeCertificationsDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly string FILTER_FIELD_EMPLOYEEID = "EMPLOYEEID";

        public GetEmployeeCertificationQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<EmployeeCertificationsDtoResponse>> Handle(GetEmployeeCertificationQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var employeeCertifications = await _dbContext.EmployeeCertifications
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => EmployeeCertificationMapping.MapToEmployeeCertificationDTO(x))
                .ToListAsync(cancellationToken);
            if (employeeCertifications == null) return Result<EmployeeCertificationsDtoResponse>.NotFound();
            return Result<EmployeeCertificationsDtoResponse>.Success(employeeCertifications);
        }
        private ISpecification<Kameyo.Core.Domain.Entities.EmployeeCertification> GetSpecification(GetEmployeeCertificationQueryRequest request)
        {
            ISpecification<Kameyo.Core.Domain.Entities.EmployeeCertification> specification = new GetEmployeeCertificationByIdSpec(request.Value);
            if (request.Field.ToUpper() == FILTER_FIELD_EMPLOYEEID)
            {
                specification = new GetEmployeeCertificationsByEmployeeIdSpec(request.Value);
            }
            return specification;
        }
    }
}
