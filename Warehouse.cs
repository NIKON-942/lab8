namespace lab8;

public class Warehouse(string name)
{
    public string Name { get; set; } = name;
    private List<Provider> _providers;
    private List<Category> _categories = [new ("Default")];
    private List<Product> _products;

    public void AddCategory(Category newCategory) =>
        _categories.Add(newCategory);

    public void RemoveCategory(Category category) =>
        _categories.Remove(category);

    public Category[] GetCategories() => 
        _categories.ToArray()[1..];

    public void PrintCategories()
    {
        Console.WriteLine($"Current warehouse: {Name}");
        foreach (var category in GetCategories())
            Console.WriteLine("\t" + category);
    }
}