using Product.Domain.Base;

namespace Product.Domain.Aggregates.ProductAggregate;

public sealed class CategoryModel : BaseEntity
{
    public CategoryModel(string title , CategoryModel? subCategory = null)
    {
        this.Title = title;
        SubCategory = subCategory;
        SubCategoryId = subCategory?.Id;
    }
    public CategoryModel(string title , long? subCategoryId = null)
    {
        this.Title = title;
        SubCategoryId = subCategoryId;
    }
    public string Title { get; private set; }
    public long? SubCategoryId { get; private set; }
    public CategoryModel SubCategory{ get; private set; }

    public void Update(CategoryModel newCategory , long? subCategoryId = null)
    {
        base.Update(newCategory.CreateIp);
        this.Title = newCategory.Title;
        this.SubCategoryId = subCategoryId;
    }
}