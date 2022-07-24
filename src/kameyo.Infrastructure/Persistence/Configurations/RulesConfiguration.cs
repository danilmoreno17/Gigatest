using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class RulesConfiguration : IEntityTypeConfiguration<Rule>
    {
        public void Configure(EntityTypeBuilder<Rule> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            
            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.Property(e => e.Formula)
                    .HasMaxLength(500)
                    .IsUnicode(false);

            builder.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.HasOne(d => d.Subsidiary)
                    .WithMany(p => p.Rules)
                    .HasForeignKey(d => d.SubsidiaryId)
                    .HasConstraintName("FK_Rules_Subsidiary");

        }
    }
}
