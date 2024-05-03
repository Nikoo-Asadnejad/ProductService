using Microsoft.EntityFrameworkCore;

namespace Product.Infrastructure.Data.Context;

public class CommandContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityTypeConfiguration<>).Assembly);
    }
}