using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.Entities;
using Kameyo.Infrastructure.Identity.Mappings;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Infrastructure.Identity.User.Queries
{
    public class GetRolesLoadOptionsQueryHandler : IRequestHandler<GetRolesLoadOptionsQueryRequest, LoadResultModel>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        public GetRolesLoadOptionsQueryHandler(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<LoadResultModel> Handle(GetRolesLoadOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            request.LoadOptions ??= new DataSourceLoadOptionsBase();
            request.LoadOptions.PrimaryKey = new string[] { "Id" };

            var roles = _roleManager.Roles
                .AsNoTracking();

            var loadResultResponse = await DataSourceLoader.LoadAsync(roles, request.LoadOptions, cancellationToken);
            loadResultResponse.data = ((IList<ApplicationRole>)loadResultResponse.data).MapToRoleDTO();

            return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK);

        }
    }
}
