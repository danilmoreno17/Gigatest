using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.MenuUserType.Dtos.Request;
using Kameyo.Core.Application.Modules.MenuUserType.Dtos.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.MenuUserType.Queries
{
    public class GetMenuQueryHandler : IRequestHandler<GetMenuQueryRequest, Result<GetMenuQueryResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IIdentityService _identityService;
        public GetMenuQueryHandler(IApplicationDbContext dbContext, IIdentityService identityService)
        {
            _dbContext = dbContext;
            _identityService = identityService;
        }
        public async Task<Result<GetMenuQueryResponse>> Handle(GetMenuQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = (await _identityService
                .GetRoleByUser(request.UserEmail))
                .Select(r => r.Id);

            var menuUserRol = await _dbContext.MenuRole
                .Include(x => x.CatalogMenu)
                .Where(x => roles.Contains(x.RoleId))
                .Select(x =>
                        new GetMenuQueryResponse()
                        {
                            Id = x.Id,
                            MenuId = x.CatalogMenu.Id,
                            MenuParentId = x.CatalogMenu.ParentId,
                            Name = x.CatalogMenu.Value,
                            Url = x.CatalogMenu.Value1 ?? string.Empty,
                            Icon = x.CatalogMenu.Value2,
                            Order = x.CatalogMenu.Order
                        })                
                .OrderBy(x => x.Order)
                .AsNoTracking()
                .ToListAsync();
            
            if (menuUserRol == null) return Result<GetMenuQueryResponse>.NotFound();

            var result = menuUserRol.GroupBy(x => x.MenuId).Select(y => y.First()).ToList();
            return Result<GetMenuQueryResponse>.Success(result);
        }
    }
}
