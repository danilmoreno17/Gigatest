using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.Entities;
using Kameyo.Infrastructure.Identity.Mappings;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;
using Kameyo.Infrastructure.Identity.User.Dtos.Response;
using Kameyo.Infrastructure.Identity.User.Specifications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Infrastructure.Identity.User.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, Result<UsersResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly string FILTER_FIELD_ID = "ID";
        private readonly string FILTER_FIELD_USERNAME = "USERNAME";
        private readonly string FILTER_FIELD_EMAIL = "EMAIL";

        public GetUserQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result<UsersResponse>> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {

            var specification = GetSpecification(request);
            var user = await _userManager.Users
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => x.MapToUserDTO())
                .FirstOrDefaultAsync();

            if (user == null) return Result<UsersResponse>.NotFound();

            return Result<UsersResponse>.Success(new List<UsersResponse>() { user });
        }
        private ISpecification<ApplicationUser> GetSpecification(GetUserQueryRequest request)
        {

            ISpecification<ApplicationUser> specification = new GetUserByIdSpec(request.Value);

            if (request.Field.ToUpper() == FILTER_FIELD_ID)
            {
                specification = new GetUserByIdSpec(request.Value);
            }

            if (request.Field.ToUpper() == FILTER_FIELD_USERNAME)
            {
                specification = new GetUserByNameSpec(request.Value);
            }

            if (request.Field.ToUpper() == FILTER_FIELD_EMAIL)
            {
                specification = new GetUserByEmailSpec(request.Value);
            }

            return specification;
        }
    }
}
