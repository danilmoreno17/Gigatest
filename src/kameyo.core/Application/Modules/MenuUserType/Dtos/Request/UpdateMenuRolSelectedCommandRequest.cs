using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.MenuUserType.Dtos.Request
{
    public class UpdateMenuRolSelectedCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid RoleId { get; set; }
        public Guid CatalogMenuId { get; set; }
        public bool MenuRolSelected { get; set; }
    }
}
