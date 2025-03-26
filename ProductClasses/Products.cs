using lab8.Interfaces;

namespace lab8.ProductClasses;

/// <summary>
/// Represents a collection of products.
/// </summary>
public class Products : ISearchable<Product>, ISortable<Products>
{
    public List<Product> ProductList = [];
    
    /// <summary>
    /// Searches for products that contain the specified keyword in their name or manufacturer.
    /// </summary>
    /// <param name="keyword">The keyword to search for.</param>
    /// <returns>A list of products matching the search criteria.</returns>
    public List<Product> Search(string keyword) =>
        ProductList.Where(prod => prod.Name.ToLower().Contains(keyword.ToLower()) 
                                       || prod.Manufacturer.ToLower().Contains(keyword.ToLower())).ToList();

    /// <summary>
    /// Sorts the list of products based on the specified criteria.
    /// </summary>
    /// <param name="criteria">The criteria to sort by. Valid options: "name", "manufacturer", and "price".</param>
    /// <param name="ascending">If <c>true</c>, sorts in ascending order; otherwise, sorts in descending order.</param>
    /// <returns>A sorted list of products.</returns>
    /// <exception cref="ArgumentException">Thrown when an invalid criteria is provided.</exception>
    public Products Sort(string criteria, bool ascending = true)
    {
        ProductList = criteria switch
        {
            "name" => ProductList.OrderBy(prod => prod.Name).ToList(),
            "manufacturer" => ProductList.OrderBy(prod => prod.Manufacturer).ToList(),
            "price" => ProductList.OrderBy(prod => prod.Price).ToList(),
            _ => throw new ArgumentException("Invalid criteria")
        };

        if (!ascending)
            ProductList.Reverse();

        return this;
    }

    /// <summary>
    /// Prints list of all products
    /// </summary>
    public void PrintList()
    {
        Console.WriteLine("List of products");
        foreach (var prod in ProductList)
            Console.WriteLine("\t" + prod);
    }
}