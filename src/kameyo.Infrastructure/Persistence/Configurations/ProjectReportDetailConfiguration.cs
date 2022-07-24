using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class ProjectReportDetailConfiguration : IEntityTypeConfiguration<ProjectReportDetail>
    {
        public void Configure(EntityTypeBuilder<ProjectReportDetail> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("ProjectReportDetail");

            
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Observation).HasColumnType("varchar(164)");

            

            builder.HasOne(d => d.ProjectReport)
                .WithMany(p => p.ProjectReportDetails)
                .HasForeignKey(d => d.ProjectReportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectReportDetail_ProjectReport");

            builder.HasOne(d => d.TaskActivity)
                .WithOne(p => p.ProjectReportDetails)
                //.HasForeignKey(d => d.TaskActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectReportDetail_TaskActivity");
        }
    }
}
