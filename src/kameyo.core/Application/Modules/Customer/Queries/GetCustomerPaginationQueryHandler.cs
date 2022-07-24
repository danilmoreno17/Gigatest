using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Customer.Dtos;
using Kameyo.Core.Application.Modules.Customer.Dtos.Request;
using Kameyo.Core.Application.Modules.Customer.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Customer.Queries
{
    public class GetCustomerPaginationQueryHandler : IRequestHandler<GetCustomerPaginationQueryRequest, ResultPaginated<CustomerDtoResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetCustomerPaginationQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResultPaginated<CustomerDtoResponse>> Handle(GetCustomerPaginationQueryRequest request, CancellationToken cancellationToken)
        {

            var validationResult = new GetCustomerPaginationQueryValidator()
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return ResultPaginated<CustomerDtoResponse>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var customer = await _context.Customers
                .Where(x => x.Active)
                .Select(x => CustomerMapping.MapToCustomerDTO(x))
                .AsNoTracking()
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return customer;
        }
    }
}
