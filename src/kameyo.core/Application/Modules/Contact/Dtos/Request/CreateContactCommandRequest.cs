using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.Contact.Dtos.Request
{
    public class CreateContactCommandRequest : IRequest<Result<string>>
    {
        public Guid? ParentId { get; set; }
        public Guid? CustomerId { get; set; }
        public string Names { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Area { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string? PhoneOffice { get; set; }
        public string? PhoneOfficeExt { get; set; }
        public string? PhoneMobile { get; set; }
    }
}
