using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.MenuUserType.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.MenuUserType.Commands
{
    public class UpdateMenuRolSelectedCommandHandler : IRequestHandler<UpdateMenuRolSelectedCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateMenuRolSelectedCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<string>> Handle(UpdateMenuRolSelectedCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Guid entityId = request.Id;

                if (request.MenuRolSelected)
                {
                    entityId = await CreateMenuUserTypeAsync(request, cancellationToken);
                }
                else
                {
                    await DeleteMenuUserTypeAsync(request, cancellationToken);
                }

                return Result<string>.Success(new List<string> { entityId.ToString() }, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Result<string>.PreconditionFailure(new() { new ResultValidationFailure() { Message = ex.Message, Name = "UpdateMenuUserTypeSelect" } });
            }

        }

        private async Task<Guid> CreateMenuUserTypeAsync(UpdateMenuRolSelectedCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.MenuRole()
            {
                UserId = request.UserId,
                RoleId = request.RoleId,
                CatalogMenuId = request.CatalogMenuId
            };

            _dbContext.MenuRole.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        private async Task DeleteMenuUserTypeAsync(UpdateMenuRolSelectedCommandRequest request, CancellationToken cancellationToken)
        {
            var entityResult = await _dbContext.MenuRole.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entityResult != null) {
                _dbContext.MenuRole.Remove(entityResult);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
