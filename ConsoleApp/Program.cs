// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Guid guid = Guid.NewGuid();
A a1 = new(guid);
A a2 = new(guid);
Console.WriteLine(a1.Equals(a2));

Console.ReadLine();

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; init; }
    public Entity(Guid id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        if (obj.GetType() != GetType())
            return false;
        if (obj is not Entity entity)
            return false;
        return entity.Id == Id;
    }

    public bool Equals(Entity? other)
    {
        if (other == null)
            return false;
        if (other.GetType() != GetType())
            return false;
        if (other is not Entity entity)
            return false;
        return entity.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

public class A : Entity
{
    public A(Guid id) : base(id)
    {
    }
}
