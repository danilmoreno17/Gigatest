using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.EmployeeCertification.Dtos.Request
{
    public class CreateEmployeeCertificationCommandRequest : IRequest<Result<string>>
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Institution { get; set; }
        public DateTime? EmissionDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
