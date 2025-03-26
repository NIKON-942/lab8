namespace lab8.ProductClasses;

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
    /// Adds the specified quantity to the current amount of the product.
    /// </summary>
    /// <param name="quantity">The quantity to add.</param>
    /// <returns>The new total quantity of the product.</returns>
    public uint AddQuantity(uint quantity) => 
        Amount += quantity;

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