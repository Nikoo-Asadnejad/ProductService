using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Aggregates.Category.AggregateRoot;

namespace Product.Infrastructure.Data.EntitytypeConfigurations.Category;

public class CategoryConfiguration : IEntityTypeConfiguration<CategoryModel>
{
    public void Configure(EntityTypeBuilder<CategoryModel> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
               .IsRequired()
               .ValueGeneratedOnAdd();

        builder.Property(c => c.Title)
               .IsRequired()
               .HasMaxLength(250);

        builder.HasOne(c => c.SubCategory)
               .WithMany()
               .HasForeignKey(c => c.SubCategoryId);
    }
}