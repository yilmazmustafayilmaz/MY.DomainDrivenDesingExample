using Domain.Abstraction;
using Domain.Categories;
using Domain.Shared;

namespace Domain.Products;

public sealed class Product : Entity
{
    private Product(Guid id) : base(id)
    {

    }
    public Product(Guid id, Guid categoryId, Name name, int quantity, Money price) : base(id)
    {
        CategoryId = categoryId;
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public Guid CategoryId { get; private set; }

    public Name Name { get; private set; }
    public int Quantity { get; private set; }
    public Money Price { get; private set; }

    public Category Category { get; private set; }

    public void ChangeName(string name)
    {
        Name = new(name);
    }
}
