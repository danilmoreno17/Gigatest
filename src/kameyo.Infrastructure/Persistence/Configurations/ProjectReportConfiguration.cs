using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class ProjectReportConfiguration : IEntityTypeConfiguration<ProjectReport>
    {
        public void Configure(EntityTypeBuilder<ProjectReport> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("ProjectReport");

            
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Created).HasDefaultValueSql("(getutcdate())");

            builder.Property(e => e.CustomerApprovedDate).HasColumnType("date");

            builder.Property(e => e.ProjectReportDate).HasColumnType("date");

            builder.Property(e => e.InvoicedDate).HasColumnType("date");

            builder.Property(e => e.PaidDate).HasColumnType("date");

            builder.HasOne(d => d.Project)
                .WithMany(p => p.ProjectReports)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectReport_Project");
        }
    }
}
