using BenchmarkDotNet.Attributes;

namespace ConsoleApp;

public class BenchMarkService
{
    [Benchmark(Baseline = true)]
    public void Equals()
    {
        int id = 1;
        Test1 test1 = new() { Id = id };
        Test1 test2 = new() { Id = id };
        Console.WriteLine(test1.Equals(test2));
        Console.ReadLine();
    }

    [Benchmark]
    public void IEquatable()
    {
        int id = 1;
        Test2 test1 = new() { Id = id };
        Test2 test2 = new() { Id = id };
        Console.WriteLine(test1.Equals(test2));
        Console.ReadLine();
    }
}

public class Test1
{
    public int Id { get; set; }
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        if (obj.GetType() != GetType())
            return false;
        if (obj is not Test1 entity)
            return false;
        return entity.Id == Id;
    }
}
public class Test2 : IEquatable<Test2>
{
    public int Id { get; set; }
    public bool Equals(Test2? other)
    {
        if (other == null)
            return false;
        if (other.GetType() != GetType())
            return false;
        if (other is not Test2 entity)
            return false;
        return entity.Id == Id;
    }
}