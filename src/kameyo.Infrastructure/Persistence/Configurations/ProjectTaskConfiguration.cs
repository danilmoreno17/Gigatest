using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("ProjectTask");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            
            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.Property(e => e.CloseDate).HasColumnType("date");

            builder.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.DurationHour).HasDefaultValueSql("((0))");

            builder.Property(e => e.EndDate).HasColumnType("date");

            builder.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.StartDate).HasColumnType("date");

            builder.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectTask_Project");
            
        }
    }
}
