using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class ProjectManagerConfiguration : IEntityTypeConfiguration<ProjectManager>
    {
        public void Configure(EntityTypeBuilder<ProjectManager> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("ProjectManager");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");            

            builder.Property(e => e.EndDate).HasColumnType("date");

            builder.Property(e => e.StartDate).HasColumnType("date");

            builder.HasOne(d => d.Employee)
                .WithMany(p => p.ProjectManagers)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectManager_Employee");

            builder.HasOne(d => d.Project)
                .WithMany(p => p.ProjectManagers)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectManager_Project");
        }
    }
}
