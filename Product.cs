namespace lab8;

public class Product
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public Category Category { get; set; }
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

    public Product(string name, string manufacturer, Category category, uint amount, decimal price)
    {
        Name = name;
        Manufacturer = manufacturer;
        Category = category;
        Amount = amount;
        Price = price;
        category.AddProduct(this);
    }

    public Product(string name, string manufacturer, Category category, uint price) : 
        this(name, manufacturer, category, 1, price) {}
    
    public Product(string name, Category category, uint price) : 
        this(name, "Not specified", category, 1, price) {}

    public override string ToString() => 
        $"Product[name={Name}, manufacturer={Manufacturer}, category={Category.Name}, amount={Amount}, price={Price}]";
}

public class Electronics(string name, string manufacturer, Category category, uint amount, uint price, uint energyConsumption) : 
    Product(name, manufacturer, category, amount, price)
{
    public uint EnergyConsumption { get; } = energyConsumption;
    
    public Electronics(string name, string manufacturer, Category category, uint price, uint energyConsumption) : 
        this(name, manufacturer, category, 1, price, energyConsumption) {}
    
    public override string ToString() => 
        $"Electronics[name={Name}, manufacturer={Manufacturer}, category={Category.Name}, amount={Amount}, price={Price}, energyConsumption={EnergyConsumption}]";
}

public class Food(string name, string manufacturer, Category category, uint amount, uint price, DateOnly expirationDate) : 
    Product(name, manufacturer, category, amount, price)
{
    public DateOnly ExpirationDate { get; } = expirationDate;

    public Food(string name, string manufacturer, Category category, uint price, DateOnly expirationDate) :
        this(name, manufacturer, category, 1, price, expirationDate) {}
    
    public Food(string name, Category category, uint price, DateOnly expirationDate) :
        this(name, "Not specified", category, 1, price, expirationDate) {}
    
    public override string ToString() => 
        $"Food[name={Name}, manufacturer={Manufacturer}, category={Category.Name}, amount={Amount}, price={Price}, expirationDate={ExpirationDate}]";
}

public class Shoes(string name, string manufacturer, Category category, uint amount, uint price, uint size) : 
    Product(name, manufacturer, category, amount, price)
{
    private uint Size { get; } = size;
    
    public Shoes(string name, string manufacturer, Category category, uint price, uint size) : 
        this(name, manufacturer, category, 1, price, size) {}
    
    public override string ToString() => 
        $"Shoes[name={Name}, manufacturer={Manufacturer}, category={Category.Name}, amount={Amount}, price={Price}, size={Size}]";
}