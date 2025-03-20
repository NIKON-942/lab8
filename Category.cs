namespace lab8;

public class Category(string name)
{
    public string Name { get; set; } = name;
    public List<Product> Products { get; } = [];

    public void AddProduct(Product product)
    {
        Products.Add(product);
        product.Category = this;
    } 

    public void RemoveProduct(Product product) => 
        Products.Remove(product);

    public override string ToString() => 
        Products.Aggregate($"Category({Name}) : [", (s, product) => s + product + " " + Environment.NewLine, s => s + "]");
}