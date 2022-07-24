namespace Kameyo.Core.Application.Modules.ProjectManager.Dtos.Response
{
    public class ProjectManagersDtoResponse
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
