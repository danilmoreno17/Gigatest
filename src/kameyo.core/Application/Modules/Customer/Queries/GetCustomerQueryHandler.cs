using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Customer.Dtos;
using Kameyo.Core.Application.Modules.Customer.Dtos.Request;
using Kameyo.Core.Application.Modules.Customer.Mapping;
using Kameyo.Core.Application.Modules.Customer.Specifications;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.Customer.Queries
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQueryRequest, Result<CustomerDtoResponse>>
    {
        private readonly IApplicationDbContext _context;

        private readonly string FILTER_FIELD_NAME = "NAME";
        private readonly string FILTER_FIELD_NUMBERID = "NUMBERID";
        private readonly string FILTER_FIELD_SUBSIDIARYID = "SUBSIDIARYID";

        public GetCustomerQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<CustomerDtoResponse>> Handle(GetCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var customer = await _context.Customers
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => CustomerMapping.MapToCustomerDTO(x))
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (customer == null) return Result<CustomerDtoResponse>.NotFound();

            return Result<CustomerDtoResponse>.Success(new List<CustomerDtoResponse>() { customer });
        }

        private ISpecification<Domain.Entities.Customer> GetSpecification(GetCustomerQueryRequest request)
        {
            ISpecification<Domain.Entities.Customer> specification = new GetCustomerByIdSpec(request.Value);

            if (request.Field.ToUpper() == FILTER_FIELD_NAME)
            {
                specification = new GetCustomerByNameSpec(request.Value);
            }

            if (request.Field.ToUpper() == FILTER_FIELD_NUMBERID)
            {
                specification = new GetCustomerByNumberIdSpec(request.Value);
            }
            if (request.Field.ToUpper() == FILTER_FIELD_SUBSIDIARYID)
            {
                specification = new GetCustomerBySubsidiaryIdSpec(request.Value);
            }
            return specification;
        }
    }
}
