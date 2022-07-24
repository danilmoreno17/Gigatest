using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class Project : BaseEntity, IHasDomainEvent
    {
        public Project()
        {
            ProjectHourBanks = new HashSet<ProjectHourBank>();
            ProjectManagers = new HashSet<ProjectManager>();
            ProjectReports = new HashSet<ProjectReport>();
            ProjectResources = new HashSet<ProjectResource>();
            ProjectTasks = new HashSet<ProjectTask>();
        }
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
        

        public virtual Customer Customer { get; set; }        
        public virtual ICollection<ProjectHourBank> ProjectHourBanks { get; set; }
        public virtual ICollection<ProjectResource> ProjectResources { get; set; }
        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
        public virtual ICollection<ProjectManager> ProjectManagers { get; set; }
        public virtual ICollection<ProjectReport> ProjectReports { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
