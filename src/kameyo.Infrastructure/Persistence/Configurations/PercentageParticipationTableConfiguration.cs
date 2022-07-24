using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class PercentageParticipationTableConfiguration : IEntityTypeConfiguration<PercentageParticipationTable>
    {
        public void Configure(EntityTypeBuilder<PercentageParticipationTable> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("PercentageParticipationTable");

            builder.Property(e => e.Percent).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.MaxValue).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.MinValue).HasColumnType("decimal(18, 2)");

        }
    }
}
