namespace lab8.Products;

public class Product
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public Category? Category { get; set; }
    public uint Amount { get; set; }

    private decimal _price;
    public decimal Price
    {
        get => _price;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Price can`t be less than zero");
            _price = value;
        }
    }

    public Product(string name, string manufacturer, uint amount, decimal price)
    {
        Name = name;
        Manufacturer = manufacturer;
        Amount = amount;
        Price = price;
    }

    public uint AddQuantity(uint quantity) => 
        Amount += quantity;

    public override string ToString() => 
        $"{Manufacturer} {Name} : {Price}$";

    public virtual string Info() => 
        $"Product [id={Id}, name={Name}, manufacturer={Manufacturer}, category={Category?.Name ?? "Not specified"}, amount={Amount}, price={Price}$]";
}