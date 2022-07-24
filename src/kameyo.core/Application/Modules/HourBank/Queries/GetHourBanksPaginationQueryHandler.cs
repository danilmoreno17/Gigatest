using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.HourBank.Dtos.Request;
using Kameyo.Core.Application.Modules.HourBank.Dtos.Response;
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
    public class GetHourBanksPaginationQueryHandler : IRequestHandler<GetHourBanksPaginationQueryRequest, ResultPaginated<HourBanksDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetHourBanksPaginationQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResultPaginated<HourBanksDtoResponse>> Handle(GetHourBanksPaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = new GetHourBanksPaginationQueryValidator()
                .Validate(request);
            if (!validationResult.IsValid)
            {
                return ResultPaginated<HourBanksDtoResponse>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var hourBanks = await _dbContext.HourBanks
                .Where(x => x.Active)
                .Select(x => HourBankMapping.MapToHourBanksDtoResponse(x))
                .AsNoTracking()
                .PaginatedListAsync(request.PageNumber, request.PageSize);
            return hourBanks;
        }
    }
}
