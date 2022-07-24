using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class ProjectResourceConfiguration : IEntityTypeConfiguration<ProjectResource>
    {
        public void Configure(EntityTypeBuilder<ProjectResource> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("ProjectResource");

            builder.HasIndex(e => e.ProjectId, "IX_ProjectResource_ProjectId");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            
            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.Property(e => e.CalculateFactorEmployee)
                   .HasColumnType("decimal(18, 2)")
                   .HasDefaultValueSql("((1))");

            builder.Property(e => e.CalculateFactorProject)
                .HasColumnType("decimal(18, 2)")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.ParticipationValue)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

            builder.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectResources)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectResource_Project");

        }
    }
}
