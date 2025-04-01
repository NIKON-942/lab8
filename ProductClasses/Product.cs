namespace lab8.ProductClasses;

public class Product
{
    public uint Id { get; internal set; }
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public Category? Category { get; internal set; }
    public uint Amount { get; private set; }

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

    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class with the specified details.
    /// </summary>
    /// <param name="name">The name of the product.</param>
    /// <param name="manufacturer">The manufacturer of the product.</param>
    /// <param name="amount">The initial quantity of the product.</param>
    /// <param name="price">The price of the product.</param>
    public Product(string name, string manufacturer, uint amount, decimal price)
    {
        Name = name;
        Manufacturer = manufacturer;
        Amount = amount;
        Price = price;
    }
    
    /// <summary>
    /// Add passed value to quantity.
    /// </summary>
    /// <param name="quantity">The quantity to add.</param>
    /// <returns>The new total quantity of the product.</returns>
    public uint ChangeQuantity(int quantity)
    {
        if (Amount + quantity < 0)
            throw new ArgumentException("Resulting quantity cannot be negative");
        Amount = (uint)(Amount + quantity);
        return Amount;
    }

    /// <summary>
    /// Returns a short string representation of the product.
    /// </summary>
    /// <returns>A string containing the manufacturer, name and price of the product.</returns>
    public override string ToString() => 
        $"({Id}) {Manufacturer, -12} {Name, -12} : {Price}$";

    /// <summary>
    /// Returns detailed information about the product.
    /// </summary>
    /// <returns>A formatted string containing the product's ID, name, manufacturer, category, amount and price.</returns>
    public virtual string Info() => 
        $"Product [id={Id}, name={Name}, manufacturer={Manufacturer}, category={Category?.Name ?? "Not specified"}, amount={Amount}, price={Price}$]";
}