using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.HourBank.Dtos.Request;
using Kameyo.Core.Application.Modules.HourBank.Dtos.Response;
using Kameyo.Core.Application.Modules.HourBank.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.HourBank.Queries
{
    public class GetHourBankQueryHandler : IRequestHandler<GetHourBankQueryRequest, Result<HourBanksDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly string FILTER_FIELD_CUSTOMERID = "CUSTOMERID";
        public GetHourBankQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<HourBanksDtoResponse>> Handle(GetHourBankQueryRequest request, CancellationToken cancellationToken)
        {

            var specification = GetSpecification(request);
            var hourBanks = await _dbContext.HourBanks
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => HourBankMapping.MapToHourBanksDtoResponse(x))
                .ToListAsync(cancellationToken);
            if (hourBanks == null) return Result<HourBanksDtoResponse>.NotFound();
            return Result<HourBanksDtoResponse>.Success(hourBanks);
        }
        private ISpecification<Kameyo.Core.Domain.Entities.HourBank> GetSpecification(GetHourBankQueryRequest request)
        {
            ISpecification<Kameyo.Core.Domain.Entities.HourBank> specification = new GetHourBanksByIdSpec(request.Value);
            if (request.Field.ToUpper() == FILTER_FIELD_CUSTOMERID)
            {
                specification = new GetHourBankByCustomerIdSpec(request.Value);
            }
            return specification;
        }
    }
}
