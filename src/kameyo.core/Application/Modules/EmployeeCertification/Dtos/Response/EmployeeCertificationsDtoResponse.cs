namespace Kameyo.Core.Application.Modules.EmployeeCertification.Dtos.Response
{
    public class EmployeeCertificationsDtoResponse
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Institution { get; set; }
        public DateTime? EmissionDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
