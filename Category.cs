namespace lab8;

/// <summary>
/// Represents a category used to classify products in the warehouse.
/// </summary>
public class Category(string name)
{
    public uint Id { get; set; }
    public string Name { get; set; } = name;

    /// <summary>
    /// Returns a string representation of the category.
    /// </summary>
    /// <returns>A string that represents the category.</returns>
    public override string ToString() => 
        $"Category({Name}, id={Id})";
}