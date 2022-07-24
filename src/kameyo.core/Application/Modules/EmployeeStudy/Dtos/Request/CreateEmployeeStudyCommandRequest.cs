using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.EmployeeStudy.Dtos.Request
{
    public class CreateEmployeeStudyCommandRequest : IRequest<Result<string>>
    {
        public Guid EmployeeId { get; set; }
        public string Institution { get; set; }
        public string Degree { get; set; }
        public string? FieldKnowledge { get; set; }
        public DateTime? EmissionDate { get; set; }
    }
}
