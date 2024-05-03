using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Aggregates.Category.AggregateRoot;
using Product.Domain.Aggregates.Product.AggregateRoot;

namespace Product.Infrastructure.Data.EntitytypeConfigurations.Product;

public class ProductConfiguration  : IEntityTypeConfiguration<ProductModel>
{
    public void Configure(EntityTypeBuilder<ProductModel> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

        builder.Property(p => p.Title)
               .IsRequired()
               .HasMaxLength(250);
        
        builder.Property(p => p.SubTitle)
                .HasMaxLength(500);

        builder.OwnsOne(p => p.Price);

        builder.HasOne(typeof(CategoryModel))
               .WithMany();

        builder.HasMany(p => p.ProductComments)
               .WithOne();
    }
}