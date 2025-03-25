namespace lab8.Products;

public class Food(string name, string manufacturer, uint amount, uint price, DateOnly expirationDate) : 
    Product(name, manufacturer, amount, price)
{
    public DateOnly ExpirationDate { get; } = expirationDate;
    
    public override string ToString() => 
        $"{Manufacturer} {Name} (use to {ExpirationDate}): {Price}$";
    
    public override string Info() => 
        $"Food[id={Id}, name={Name}, manufacturer={Manufacturer}, category={Category?.Name ?? "Not specified"}, amount={Amount}, price={Price}$, expirationDate={ExpirationDate}]";
}