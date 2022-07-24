using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class Employee : BaseEntity, IHasDomainEvent
    {
        public Employee()
        {
            ProjectManagers = new HashSet<ProjectManager>();
        }

        public Guid? ParentId { get; set; }
        public Guid SubsidiaryId { get; set; }
        public string Names { get; set; } = null!;
        public string? LastName { get; set; }
        public Guid? CatalogAreaId { get; set; }
        public Guid? CatalogDepartmentId { get; set; }
        public Guid? CatalogCostCenterId { get; set; }
        public Guid? CatalogPositionId { get; set; }
        public Guid? CatalogCurrencyId { get; set; }
        public Guid? CatalogEmployeeTypeId { get; set; }
        public decimal CostHour { get; set; }
        public string? PhoneOffice { get; set; }
        public string? PhoneOfficeExt { get; set; }
        public string? PhoneMobile { get; set; }
        public decimal CalculateFactor { get; set; } = 1;

        public virtual Subsidiary Subsidiary { get; set; }
        public virtual ICollection<ProjectManager> ProjectManagers { get; set; }
        public virtual ICollection<EmployeeAward> EmployeeAwards { get; set; }
        public virtual ICollection<EmployeeCertification> EmployeeCertifications { get; set; }
        public virtual ICollection<EmployeeExperience> EmployeeExperiences { get; set; }
        public virtual ICollection<EmployeeSkillAbility> EmployeeSkillAbilities { get; set; }
        public virtual ICollection<EmployeeStudy> EmployeeStudies { get; set; }
        public virtual ICollection<FinancialParticipation> FinancialParticipations { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
