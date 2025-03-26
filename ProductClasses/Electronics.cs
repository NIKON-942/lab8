namespace lab8.ProductClasses;

/// <summary>
/// Represents an electronics product.
/// </summary>
/// <param name="name">The name of the electronics product.</param>
/// <param name="manufacturer">The manufacturer of the electronics product.</param>
/// <param name="amount">The quantity available.</param>
/// <param name="price">The price of the electronics product.</param>
/// <param name="energyConsumption">The energy consumption in Watts of the electronics product.</param>
public class Electronics(string name, string manufacturer, uint amount, uint price, uint energyConsumption) : 
    Product(name, manufacturer, amount, price)
{
    public uint EnergyConsumption { get; } = energyConsumption;
    
    /// <summary>
    /// Returns a short string representation of the electronics product.
    /// </summary>
    /// <returns>A string containing the manufacturer, name, energy consumption and price.</returns>
    public override string ToString() => 
        $"({Id}) {Manufacturer, -12} {Name, -12} ({EnergyConsumption}W): {Price}$";
    
    /// <summary>
    /// Returns detailed information about the electronics product.
    /// </summary>
    /// <returns>A formatted string with detailed information including ID, name, manufacturer, category, amount, price and energy consumption.</returns>
    public override string Info() => 
        $"Electronics[id={Id}, name={Name}, manufacturer={Manufacturer}, category={Category?.Name ?? "Not specified"}, amount={Amount}, price={Price}$, energyConsumption={EnergyConsumption}]";
}