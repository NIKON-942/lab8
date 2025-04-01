using lab8.Interfaces;

namespace lab8.ProductClasses;

/// <summary>
/// Represents a collection of products.
/// </summary>
public class Products(Warehouse warehouse) : ISearchable<Product>, ISortable<Product>
{
    private uint _nextProductId;
    private readonly List<Product> _productList = [];
    
    /// <summary>
    /// Adds a new product to the warehouse and assigns it to a specified category.
    /// </summary>
    /// <param name="newProduct">The product to add.</param>
    /// <param name="catId">The ID of the category to assign the product to. Defaults to the default category if not specified.</param>
    /// <returns>The ID of the added product.</returns>
    public uint AddProduct(Product newProduct, uint catId = 0)
    {
        _productList.Add(newProduct);
        var category = warehouse.Categories.GetCategoryById(catId);
        if (category == null)
            throw new ArgumentException($"Category with id = {catId} does not exist");
        newProduct.Category = category;
        newProduct.Id = _nextProductId++;
        return newProduct.Id;
    }
    
    /// <summary>
    /// Removes product from a warehouse.
    /// </summary>
    /// <param name="id">The ID of the product to remove.</param>
    public void RemoveProduct(uint id)
    {
        var product = _productList.FirstOrDefault(prod => prod.Id == id);
        if (product != null)
            _productList.Remove(product);
    }
    
    /// <summary>
    /// Adds an existing product to a specified category.
    /// </summary>
    /// <param name="prodId">The ID of the product to add to the category.</param>
    /// <param name="catId">The ID of the category to assign the product to.</param>
    /// <returns>The ID of the product.</returns>
    public uint AddProductToCategory(uint prodId, uint catId)
    {
        var product = _productList.FirstOrDefault(prod => prod.Id == prodId);
        var category = warehouse.Categories.GetCategoryById(catId);
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
        var product = _productList.FirstOrDefault(prod => prod.Id == prodId);
        if (product != null)
            product.Category = warehouse.Categories.GetCategoryById(0);
        return prodId;
    }
    
    /// <summary>
    /// Searches for products that contain the specified keyword in their name or manufacturer.
    /// </summary>
    /// <param name="keyword">The keyword to search for.</param>
    /// <returns>A list of products matching the search criteria.</returns>
    public List<Product> Search(string keyword) =>
        _productList.Where(prod => prod.Name.ToLower().Contains(keyword.ToLower()) 
                                        || prod.Manufacturer.ToLower().Contains(keyword.ToLower())).ToList();

    /// <summary>
    /// Sorts the list of products based on the specified criteria.
    /// </summary>
    /// <param name="criteria">The criteria to sort by. Valid options: "name", "manufacturer", and "price".</param>
    /// <param name="ascending">If <c>true</c>, sorts in ascending order; otherwise, sorts in descending order.</param>
    /// <returns>A sorted list of products.</returns>
    /// <exception cref="ArgumentException">Thrown when an invalid criteria is provided.</exception>
    public List<Product> Sort(string criteria, bool ascending = true)
    {
        var result = criteria switch
        {
            "name" => _productList.OrderBy(prod => prod.Name).ToList(),
            "manufacturer" => _productList.OrderBy(prod => prod.Manufacturer).ToList(),
            "price" => _productList.OrderBy(prod => prod.Price).ToList(),
            _ => throw new ArgumentException("Invalid criteria")
        };

        if (!ascending)
            result.Reverse();

        return result;
    }

    /// <summary>
    /// Prints list of all products
    /// </summary>
    public void PrintList()
    {
        Console.WriteLine("List of products:");
        foreach (var prod in _productList)
            Console.WriteLine("\t" + prod);
    }
    
    /// <summary>
    /// Retrieves a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <returns>The product if found, otherwise null.</returns>
    public Product? GetProduct(uint id) =>
        _productList.FirstOrDefault(prod => prod.Id == id);

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    public List<Product> GetAllProducts() =>
        _productList;
}