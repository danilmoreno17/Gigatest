using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class TaskActivityConfiguration : IEntityTypeConfiguration<TaskActivity>
    {
        public void Configure(EntityTypeBuilder<TaskActivity> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("TaskActivity");
            builder.HasIndex(e => e.ProjectTaskId, "IX_TaskActivity_ProjectTaskId");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");            
            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.EndDate).HasColumnType("datetime");

            builder.Property(e => e.StartDate).HasColumnType("datetime");

            builder.Property(e => e.HourCost).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.CalculateFactor).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.TotalTimeHour).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.TotalTimeHourApproved).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.InProjectReportDate).HasColumnType("date");

            builder.Property(e => e.InvoicedDate).HasColumnType("date");

            builder.Property(e => e.PaidDate).HasColumnType("date");

            builder.HasOne(d => d.ProjectTask)
                    .WithMany(p => p.TaskActivities)
                    .HasForeignKey(d => d.ProjectTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskActivity_ProjectTask");

        }
    }
}
