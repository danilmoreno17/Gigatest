using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class ProjectHourBankConfiguration : IEntityTypeConfiguration<ProjectHourBank>
    {
        public void Configure(EntityTypeBuilder<ProjectHourBank> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("ProjectHourBank");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            
            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectHourBanks)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectHourBank_Project");
            
        }
    }
}
