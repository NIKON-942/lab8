using lab8.Interfaces;

namespace lab8.Products;

public class Products : ISearchable<Product>, ISortable<Product>
{
    public readonly List<Product> ProductList = [];
    
    public List<Product> Search(string keyword) =>
        ProductList.Where(prod => prod.Name.ToLower().Contains(keyword.ToLower()) 
                                      || prod.Manufacturer.ToLower().Contains(keyword.ToLower())).ToList();

    public List<Product> Sort(string criteria, bool ascending = true)
    {
        var result = criteria switch
        {
            "name" => ProductList.OrderBy(prod => prod.Name).ToList(),
            "manufacturer" => ProductList.OrderBy(prod => prod.Manufacturer).ToList(),
            "price" => ProductList.OrderBy(prod => prod.Price).ToList(),
            _ => throw new ArgumentException("Invalid criteria")
        };

        if (!ascending)
            result.Reverse();

        return result;
    }
}