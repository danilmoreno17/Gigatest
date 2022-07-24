using Kameyo.Core.Application.Common.Enums;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.MenuUserType.Dtos.Request;
using Kameyo.Core.Application.Modules.MenuUserType.Dtos.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.MenuUserType.Queries
{
    public class GetMenuUserTypeQueryHandler : IRequestHandler<GetMenuUserTypeQueryRequest, Result<GetMenuUserTypeQueryResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetMenuUserTypeQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<GetMenuUserTypeQueryResponse>> Handle(GetMenuUserTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var menuUserTypeSelected = await _dbContext.MenuRole
                .Where(x => x.RoleId == request.roleId)
                .ToListAsync(cancellationToken);

            var menuUserType = await _dbContext.Catalogs
                .Where(x => x.Name == CatalogsEnum.MENUS.Name)                
                .OrderBy(x => x.Order)
                .AsNoTracking()
                .ToListAsync(cancellationToken);


            var response = menuUserType.MapToMenuUserTypeDto(menuUserTypeSelected, request.roleId);

            return Result<GetMenuUserTypeQueryResponse>.Success(response);


        }
    }
}
