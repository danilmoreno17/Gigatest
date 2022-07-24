namespace Kameyo.Core.Application.Modules.EmployeeAward.Dtos.Response
{
    public class EmployeeAwardDtoResponse
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Institution { get; set; }
        public string? Description { get; set; }
        public DateTime? AwardDate { get; set; }
    }
}
