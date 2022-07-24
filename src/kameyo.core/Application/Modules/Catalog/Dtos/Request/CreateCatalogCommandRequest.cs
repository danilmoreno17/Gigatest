using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.Catalog.Dtos.Request
{
    public class CreateCatalogCommandRequest : IRequest<Result<string>>
    {
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string? Description { get; set; } = null!;        
        public int Order { get; set; }
        public bool IsSystemOwner { get; set; } = false;
        public int? Status { get; set; }
    }
}
