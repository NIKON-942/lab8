using lab8.CategoryClasses;
using lab8.ProductClasses;
using lab8.SupplierClasses;

namespace lab8;

/// <summary>
/// Represents a warehouse that manages categories, products and suppliers.
/// </summary>
public class Warehouse
{
    public string Name { get; }
    public readonly Categories Categories;
    public readonly Products Products;
    public readonly Suppliers Suppliers;

    public Warehouse(string name)
    {
        Name = name;
        Categories = new Categories(this);
        Products = new Products(this);
        Suppliers = new Suppliers();
    }
}