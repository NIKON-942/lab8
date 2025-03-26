using lab8.ProductClasses;
using lab8.SupplierClasses;

namespace lab8;

/// <summary>
/// Represents a warehouse that manages categories, products, and suppliers.
/// </summary>
public class Warehouse(string name)
{
    private uint _nextCategoryId = 1;
    private uint _nextProductId;
    private uint _nextSupplierId;

    public string Name { get; set; } = name;
    public readonly List<Category> Categories = [new ("Default") { Id = 0 }];
    public readonly Products Products = new ();
    public readonly Suppliers Suppliers = new ();

    /// <summary>
    /// Adds a new category to the warehouse.
    /// </summary>
    /// <param name="name">The name of the new category.</param>
    /// <returns>The ID of the added category.</returns>
    public uint AddCategory(string name)
    {
        var category = new Category(name) { Id = _nextCategoryId++ };
        Categories.Add(category);
        return category.Id;
    }

    /// <summary>
    /// Removes a category by ID and reassigns its products to the default category.
    /// </summary>
    /// <param name="id">The ID of the category to remove.</param>
    /// <exception cref="ArgumentException">Thrown when a passed ID equals 0.</exception>
    public void RemoveCategory(uint id)
    {
        if (id == 0)
            throw new ArgumentException("Can't delete Default category");
        var category = Categories.FirstOrDefault(cat => cat.Id == id);
        if (category == null)
            return;
        Categories.Remove(category);
        var productsFromCategory = Products.ProductList.Where(prod => prod.Category!.Id == id);
        foreach (var prod in productsFromCategory)
            prod.Category = Categories[0];
    }

    /// <summary>
    /// Updates the name of an existing category.
    /// </summary>
    /// <param name="id">The ID of the category to update.</param>
    /// <param name="newName">The new name for the category.</param>
    /// <returns>The ID of the updated category.</returns>
    /// <exception cref="ArgumentException">Thrown when a category with passed ID does not exist</exception>
    public uint UpdateCategory(uint id, string newName)
    {
        var category = Categories.FirstOrDefault(cat => cat.Id == id);
        if (category == null)
            throw new ArgumentException($"Category with id = {id} does not exist");
        category.Name = newName;
        return id;
    }

    /// <summary>
    /// Displays the details of a specific category with its products.
    /// </summary>
    /// <param name="id">The ID of the category to view.</param>
    /// <exception cref="ArgumentException">Thrown when a category with passed ID does not exist</exception>
    public void ViewCategory(uint id)
    {
        var category = Categories.FirstOrDefault(cat => cat.Id == id);
        if (category == null)
            throw new ArgumentException($"Category with id = {id} does not exist");
        Console.WriteLine($"{category}:");
        var products = Products.ProductList.Where(prod => prod.Category!.Id == id);
        foreach (var prod in products)
            Console.WriteLine("\t" + prod);
    }

    /// <summary>
    /// Displays all categories and their products.
    /// </summary>
    public void ViewAllCategories()
    {
        Console.WriteLine($"All categories ({Name}):");
        foreach (var cat in Categories)
        {
            Console.WriteLine($"\t{cat}:");
            var products = Products.ProductList.Where(prod => prod.Category == cat);
            foreach (var prod in products)
                Console.WriteLine("\t\t" + prod);
        }
    }

    /// <summary>
    /// Adds a new product to the warehouse and assigns it to a specified category.
    /// </summary>
    /// <param name="newProduct">The product to add.</param>
    /// <param name="catId">The ID of the category to assign the product to. Defaults to the default category if not specified.</param>
    /// <returns>The ID of the added product.</returns>
    public uint AddProduct(Product newProduct, uint catId = 0)
    {
        Products.ProductList.Add(newProduct);
        newProduct.Category = Categories.FirstOrDefault(cat => cat.Id == catId, Categories[0]);
        newProduct.Id = _nextProductId++;
        return newProduct.Id;
    }

    /// <summary>
    /// Assigns an existing product to a different category.
    /// </summary>
    /// <param name="prodId">The ID of the product.</param>
    /// <param name="catId">The ID of the category to which the product will be assigned.</param>
    /// <returns>The ID of the product.</returns>
    /// <exception cref="ArgumentException">Thrown when category or product with passed ID does not exist.</exception>
    public uint AddProductToCategory(uint prodId, uint catId)
    {
        var product = Products.ProductList.FirstOrDefault(prod => prod.Id == prodId);
        var category = Categories.FirstOrDefault(cat => cat.Id == catId);
        if (product != null && category != null)
            product.Category = category;
        else if (product == null)
            throw new ArgumentException($"Product with id = {prodId} does not exist");
        else
            throw new ArgumentException($"Category with id = {prodId} does not exist");
        return prodId;
    }

    /// <summary>
    /// Removes a product from its current category and reassign it to the default category.
    /// </summary>
    /// <param name="prodId">The ID of the product to update.</param>
    /// <returns>The ID of the product.</returns>
    public uint RemoveProductFromCategory(uint prodId)
    {
        var product = Products.ProductList.FirstOrDefault(prod => prod.Id == prodId);
        if (product != null)
            product.Category = Categories[0];
        return prodId;
    }

    /// <summary>
    /// Removes product from a warehouse.
    /// </summary>
    /// <param name="id">The ID of the product to remove.</param>
    public void RemoveProduct(uint id)
    {
        var product = Products.ProductList.FirstOrDefault(prod => prod.Id == id);
        if (product != null)
            Products.ProductList.Remove(product);
    }

    /// <summary>
    /// Retrieves a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <returns>The product if found, otherwise null.</returns>
    public Product? GetProduct(uint id) =>
        Products.ProductList.FirstOrDefault(prod => prod.Id == id);

    /// <summary>
    /// Adds a new supplier to the warehouse.
    /// </summary>
    /// <param name="newSupplier">The supplier to add.</param>
    /// <returns>The ID of the added supplier.</returns>
    public uint AddSupplier(Supplier newSupplier)
    {
        Suppliers.SupplierList.Add(newSupplier);
        newSupplier.Id = _nextSupplierId++;
        return newSupplier.Id;
    }

    /// <summary>
    /// Removes a supplier from the warehouse.
    /// </summary>
    /// <param name="suppId">The ID of the supplier to remove.</param>
    public void RemoveSupplier(uint suppId)
    {
        var supplier = Suppliers.SupplierList.FirstOrDefault(supp => supp.Id == suppId);
        if (supplier != null)
            Suppliers.SupplierList.Remove(supplier);
    }

    /// <summary>
    /// Retrieves a supplier by its ID.
    /// </summary>
    /// <param name="id">The ID of the supplier.</param>
    /// <returns>The supplier if found, otherwise null.</returns>
    public Supplier? GetSupplier(uint id) =>
        Suppliers.SupplierList.FirstOrDefault(supp => supp.Id == id);
}