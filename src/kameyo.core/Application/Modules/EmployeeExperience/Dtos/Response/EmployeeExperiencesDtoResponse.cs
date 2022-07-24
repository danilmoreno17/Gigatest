namespace Kameyo.Core.Application.Modules.EmployeeExperience.Dtos.Response
{
    public class EmployeeExperiencesDtoResponse
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string? Type { get; set; }
        public string? CompanyCity { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string? Description { get; set; }
    }
}
