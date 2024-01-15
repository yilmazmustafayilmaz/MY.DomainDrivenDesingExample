using Domain.Abstraction;
using Domain.Products;
using Domain.Shared;

namespace Domain.Categories;

public sealed class Category : Entity
{
    public Category(Guid id) : base(id)
    {

    }
    public Category(Guid id, Name name) : base(id)
    {
        Name = name;
    }

    public Name Name { get; private set; }

    public ICollection<Product> Products { get; private set; }

    public void ChangeName(string name)
    {
        Name = new(name);
    }
}
