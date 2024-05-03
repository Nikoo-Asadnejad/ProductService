using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Infrastructure.Data.EntitytypeConfigurations.ChangeHistory;

public class ChangeLogConfiguration : IEntityTypeConfiguration<Domain.Aggregates.Shared.ChangeHistory.AggregateRoot.ChangeHistory>
{
    public void Configure(EntityTypeBuilder<Domain.Aggregates.Shared.ChangeHistory.AggregateRoot.ChangeHistory> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.RelatedEntityType)
               .HasMaxLength(150);
    }
}

