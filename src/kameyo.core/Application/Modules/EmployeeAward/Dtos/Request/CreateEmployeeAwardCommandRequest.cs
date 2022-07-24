using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.EmployeeAward.Dtos.Request
{
    public class CreateEmployeeAwardCommandRequest : IRequest<Result<string>>
    {
        public Guid EmployeeId { get; set; }
        public string Institution { get; set; }
        public string? Description { get; set; }
        public DateTime? AwardDate { get; set; }
    }
}
