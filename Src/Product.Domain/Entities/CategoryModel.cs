namespace Product.Domain.Entities;

public sealed class CategoryModel : BaseModel<long>
{
    public CategoryModel(string title , ICollection<CategoryModel>? subCategories = null)
    {
        base.Create();
        this.Title = title;
        SubCategories = subCategories ?? new List<CategoryModel>();
    }
    public string Title { get; private set; }
    public ICollection<CategoryModel> SubCategories { get; private set; }

    public void Update(CategoryModel newCategory)
    {
        base.Update(newCategory.CreateIp);
        this.Title = newCategory.Title;
    }
}