using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.Project.Dtos.Request
{
    public class CreateProjectCommandRequest : IRequest<Result<string>>
    {
        public Guid? CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? CatalogProjectTypeId { get; set; }
        public Guid? CatalogProjectCategoryId { get; set; }
        public Guid? CatalogProjectStateId { get; set; }
        public Guid? MainContactId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? DurationHour { get; set; }
        public DateTime? CloseDate { get; set; }
        public decimal CostHourMenCustomer { get; set; }
        public decimal CostHourMenProject { get; set; }
    }
}
