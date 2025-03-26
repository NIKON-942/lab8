namespace lab8.ProductClasses;

/// <summary>
/// Represents a food product.
/// </summary>
/// <param name="name">The name of the food product.</param>
/// <param name="manufacturer">The manufacturer of the food product.</param>
/// <param name="amount">The quantity available.</param>
/// <param name="price">The price of the food product.</param>
/// <param name="expirationDate">The expiration date of the food product.</param>
public class Food(string name, string manufacturer, uint amount, uint price, DateOnly expirationDate) : 
    Product(name, manufacturer, amount, price)
{
    public DateOnly ExpirationDate { get; } = expirationDate;
    
    /// <summary>
    /// Returns a short string representation of the food product.
    /// </summary>
    /// <returns>A string containing the manufacturer, name, expiration date and price.</returns>
    public override string ToString() => 
        $"({Id}) {Manufacturer, -12} {Name, -12} (use to {ExpirationDate}): {Price}$";
    
    /// <summary>
    /// Returns detailed information about the food product.
    /// </summary>
    /// <returns>A formatted string with detailed information including ID, name, manufacturer, category, amount, price and expiration date.</returns>
    public override string Info() => 
        $"Food[id={Id}, name={Name}, manufacturer={Manufacturer}, category={Category?.Name ?? "Not specified"}, amount={Amount}, price={Price}$, expirationDate={ExpirationDate}]";
}