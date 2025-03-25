namespace lab8.ProductClasses;

/// <summary>
/// Represents a pair of shoes product.
/// </summary>
/// <param name="name">The name of the shoes.</param>
/// <param name="manufacturer">The manufacturer of the shoes.</param>
/// <param name="amount">The quantity available.</param>
/// <param name="price">The price of the shoes.</param>
/// <param name="size">The size of the shoes.</param>
public class Shoes(string name, string manufacturer, uint amount, uint price, uint size) : 
    Product(name, manufacturer, amount, price)
{
    private uint Size { get; } = size;
    
    /// <summary>
    /// Returns a short string representation of the shoes.
    /// </summary>
    /// <returns>A string containing the manufacturer, name, size and price.</returns>
    public override string ToString() => 
        $"{Manufacturer} {Name} ({Size} size): {Price}$";
    
    /// <summary>
    /// Returns detailed information about the shoes.
    /// </summary>
    /// <returns>A formatted string with detailed information including ID, name, manufacturer, category, amount, price and size.</returns>
    public override string Info() => 
        $"Shoes[id={Id}, name={Name}, manufacturer={Manufacturer}, category={Category?.Name ?? "Not specified"}, amount={Amount}, price={Price}$, size={Size}]";
}