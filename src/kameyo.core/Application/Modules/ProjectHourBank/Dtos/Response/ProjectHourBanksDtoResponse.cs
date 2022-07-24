namespace Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Response
{
    public class ProjectHourBanksDtoResponse
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid HourBankId { get; set; }
        public int? HourBalance { get; set; }
        public int? HourSet { get; set; }
    }
}
