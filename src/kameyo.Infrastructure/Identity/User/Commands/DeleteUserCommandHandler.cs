using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.Entities;
using Kameyo.Infrastructure.Identity.User.Commands.Validators;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Kameyo.Infrastructure.Identity.User.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, Result<string>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public DeleteUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<string>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());

            var validationResult = new DeleteUserCommandValidator(user != null)
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }


            user.Active = false;

            var resultUpdate = await _userManager.UpdateAsync(user);

            if (!resultUpdate.Succeeded)
            {
                return Result<string>.PreconditionFailure(resultUpdate.Errors.MapToResultValidationFailure());
            }

            return Result<string>.Success(new List<string> { user.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
