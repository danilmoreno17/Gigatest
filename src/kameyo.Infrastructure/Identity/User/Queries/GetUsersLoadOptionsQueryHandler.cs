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
    public class GetUsersLoadOptionsQueryHandler : IRequestHandler<GetUsersLoadOptionsQueryRequest, LoadResultModel>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        

        public GetUsersLoadOptionsQueryHandler(UserManager<ApplicationUser> userManager  )
        {
            _userManager = userManager;            
        }

        public async Task<LoadResultModel> Handle(GetUsersLoadOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            request.LoadOptions ??= new DataSourceLoadOptionsBase();
            request.LoadOptions.PrimaryKey = new string[] { "Id" };
            
            var users = _userManager.Users
                .Include(x => x.UserRoles)
                .Where(x => x.Active)
                .AsNoTracking();

            var loadResultResponse = await DataSourceLoader.LoadAsync(users, request.LoadOptions, cancellationToken);
            loadResultResponse.data =  ((IList<ApplicationUser>)loadResultResponse.data).MapToUserDTO();

            return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK);
        }
    }
}
