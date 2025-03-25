using lab8.Products;
using lab8.Suppliers;

namespace lab8;

public class Warehouse(string name)
{
    private uint _nextCategoryId = 1;
    private uint _nextProductId = 1;
    private uint _nextSupplierId = 1;

    public string Name { get; set; } = name;
    public readonly List<Category> Categories = [new ("Default") { Id = 0 }];
    public readonly Products.Products Products = new ();
    public readonly Suppliers.Suppliers Suppliers = new ();

    public uint AddCategory(string name)
    {
        var category = new Category(name) { Id = _nextCategoryId++ };
        Categories.Add(category);
        return category.Id;
    }

    public void RemoveCategory(uint id)
    {
        var category = Categories.FirstOrDefault(cat => cat.Id == id);
        if (category == null)
            return;
        Categories.Remove(category);
        var productsFromCategory = Products.ProductList.Where(prod => prod.Category!.Id == id);
        foreach (var prod in productsFromCategory)
            prod.Category = Categories[0];
    }

    public uint UpdateCategory(uint id, string newName)
    {
        var category = Categories.FirstOrDefault(cat => cat.Id == id);
        if (category != null)
            category.Name = newName;
        return id;
    }

    public void ViewCategory(uint id)
    {
        var category = Categories.FirstOrDefault(cat => cat.Id == id);
        if (category == null)
            return;
        Console.WriteLine($"{category}:");
        var products = Products.ProductList.Where(prod => prod.Category!.Id == id);
        foreach (var prod in products)
            Console.WriteLine("\t" + prod);
    }

    public void ViewAllCategories()
    {
        Console.WriteLine("All categories:");
        foreach (var cat in Categories)
        {
            Console.WriteLine($"\t{cat}:");
            var products = Products.ProductList.Where(prod => prod.Category == cat);
            foreach (var prod in products)
                Console.WriteLine("\t\t" + prod);
        }
    }

    public uint AddProduct(Product newProduct, uint catId)
    {
        Products.ProductList.Add(newProduct);
        newProduct.Category = Categories.FirstOrDefault(cat => cat.Id == catId, Categories[0]);
        newProduct.Id = _nextProductId++;
        return newProduct.Id;
    }

    public uint AddProductToCategory(uint prodId, uint catId)
    {
        var product = Products.ProductList.FirstOrDefault(prod => prod.Id == prodId);
        var category = Categories.FirstOrDefault(cat => cat.Id == catId);
        if (product != null && category != null)
            product.Category = category;
        return prodId;
    }

    public uint DeleteProductFromCategory(uint prodId)
    {
        var product = Products.ProductList.FirstOrDefault(prod => prod.Id == prodId);
        if (product != null)
            product.Category = Categories[0];
        return prodId;
    }

    public Product? GetProduct(uint id) =>
        Products.ProductList.FirstOrDefault(prod => prod.Id == id);

    public uint AddSupplier(Supplier newSupplier)
    {
        Suppliers.SupplierList.Add(newSupplier);
        newSupplier.Id = _nextSupplierId++;
        return newSupplier.Id;
    }

    public void RemoveSupplier(uint suppId)
    {
        var supplier = Suppliers.SupplierList.FirstOrDefault(supp => supp.Id == suppId);
        if (supplier == null)
            return;
        Suppliers.SupplierList.Remove(supplier);
    }

    public Supplier? GetSupplier(uint id) =>
        Suppliers.SupplierList.FirstOrDefault(supp => supp.Id == id);
}