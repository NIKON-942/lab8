using lab8.Products;

namespace lab8;

public class Category(string name)
{
    public uint Id { get; set; }
    public string Name { get; set; } = name;

    public override string ToString() => 
        $"Category({Name})";
}