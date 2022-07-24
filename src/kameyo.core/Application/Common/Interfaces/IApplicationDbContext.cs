using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<Catalog> Catalogs { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Contact> Contacts { get; set; } 
        DbSet<Customer> Customers { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<HourBank> HourBanks { get; set; }        
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectHourBank> ProjectHourBanks { get; set; }

        DbSet<ProjectReport> ProjectReport { get; set; }
        DbSet<ProjectReportDetail> ProjectReportDetail { get; set; }
        DbSet<ProjectResource> ProjectResources { get; set; }
        DbSet<ProjectTask> ProjectTasks { get; set; }
        DbSet<Rule> Rules { get; set; }
        DbSet<Subsidiary> Subsidiaries { get; set; }
        DbSet<TaskActivity> TaskActivities { get; set; }
        DbSet<ProjectManager> ProjectManagers { get; set; }
        DbSet<EmployeeAward> EmployeeAwards { get; set; }
        DbSet<EmployeeCertification> EmployeeCertifications { get; set; }
        DbSet<EmployeeExperience> EmployeeExperiences { get; set; }
        DbSet<EmployeeSkillAbility> EmployeeSkillAbilities { get; set; }
        DbSet<PercentageParticipationTable> PercentageParticipationTable { get; set; }

        DbSet<EmployeeStudy> EmployeeStudies { get; set; }
        DbSet<MenuRole> MenuRole { get; set; }         
        DbSet<FinancialParticipation> FinancialParticipation { get; set; } 

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
