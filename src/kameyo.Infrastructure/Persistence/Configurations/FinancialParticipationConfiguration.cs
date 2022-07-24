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
    internal class FinancialParticipationConfiguration : IEntityTypeConfiguration<FinancialParticipation>
    {
        public void Configure(EntityTypeBuilder<FinancialParticipation> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("FinancialParticipation");


            builder.Property(e => e.Value).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.Employee)
                .WithMany(p => p.FinancialParticipations)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FinancialParticipation_Employee");


        }
    }
}
