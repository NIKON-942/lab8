namespace lab8.Products;

public class Electronics(string name, string manufacturer, uint amount, uint price, uint energyConsumption) : 
    Product(name, manufacturer, amount, price)
{
    public uint EnergyConsumption { get; } = energyConsumption;
    
    public override string ToString() => 
        $"{Manufacturer} {Name} ({EnergyConsumption}W): {Price}$";
    
    public override string Info() => 
        $"Electronics[id={Id}, name={Name}, manufacturer={Manufacturer}, category={Category?.Name ?? "Not specified"}, amount={Amount}, price={Price}$, energyConsumption={EnergyConsumption}]";
}