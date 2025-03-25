namespace lab8.Products;

public class Shoes(string name, string manufacturer, uint amount, uint price, uint size) : 
    Product(name, manufacturer, amount, price)
{
    private uint Size { get; } = size;
    
    public override string ToString() => 
        $"{Manufacturer} {Name} ({Size} size): {Price}$";
    
    public override string Info() => 
        $"Shoes[id={Id}, name={Name}, manufacturer={Manufacturer}, category={Category?.Name ?? "Not specified"}, amount={Amount}, price={Price}$, size={Size}]";
}