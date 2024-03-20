namespace Product.Domain.Shared.ValueObjects;

public class CategoryId : BaseId<int>
{
    public CategoryId(int id) : base(id)
    {
    }
}