using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class EmployeeSkillAbilityConfiguration : IEntityTypeConfiguration<EmployeeSkillAbility>
    {
        public void Configure(EntityTypeBuilder<EmployeeSkillAbility> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("EmployeeSkillAbility");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.HasIndex(e => e.EmployeeId, "IX_EmployeeSkillAbility_EmployeeId");

            builder.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.HasOne(e => e.Employee)
                .WithMany(p => p.EmployeeSkillAbilities)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSkillAbility_Employee");
        }
    }
}
