using lab8.ProductClasses;
using lab8.SupplierClasses;

namespace lab8;

public static class Program
{
    public static void Main()
    {
        var warehouse = new Warehouse("Auchan");
        Console.WriteLine("Creating new categories");
        warehouse.Categories.ViewAllCategories();
        warehouse.Categories.AddCategory("Bakery");
        warehouse.Categories.AddCategory("Recreation");
        warehouse.Categories.AddCategory("Household");
        warehouse.Categories.AddCategory("Test");
        warehouse.Categories.ViewAllCategories();
        
        Console.WriteLine("Removing category with id = 2");
        warehouse.Categories.RemoveCategory(2);
        warehouse.Categories.ViewAllCategories();
        
        Console.WriteLine("Updating category with id = 3 to \"Garden\"");
        warehouse.Categories.UpdateCategory(3, "Garden");
        warehouse.Categories.UpdateCategory(4, "TestTest");
        warehouse.Categories.ViewAllCategories();
        
        var product1 = new Product("Scissors", "Scotch", 150, 4);
        var product2 = new Electronics("Mixer", "Bosch", 10, 30, 400);
        var product3 = new Food("Pizza", "Chicago Town", 30, 5, new DateOnly(2025, 04, 12));
        var product4 = new Shoes("Air Jordan", "Nike", 20, 120, 43);
        var product5 = new Food("Bar", "Roshen", 400, 2, new DateOnly(2025, 04, 30));

        Console.WriteLine("Adding products to categories");
        warehouse.Products.AddProduct(product1, 3);
        warehouse.Products.AddProduct(product2, 1);
        warehouse.Products.AddProduct(product3, 1);
        warehouse.Products.AddProduct(product4);
        warehouse.Products.AddProduct(product5, 1);
        warehouse.Categories.ViewAllCategories();

        Console.WriteLine("----" + warehouse.Categories.GetCategoryById(1));
        
        Console.WriteLine("Removing product with id = 4 from category");
        warehouse.Products.RemoveProductFromCategory(4);
        warehouse.Categories.ViewAllCategories();
        
        Console.WriteLine("Removing product with id = 2 from warehouse");
        warehouse.Products.RemoveProduct(2);
        warehouse.Categories.ViewAllCategories();

        Console.WriteLine("Changing product data for id = 3");
        var productToChange = warehouse.Products.GetProduct(3);
        if (productToChange != null)
        {
            productToChange.Name = "Air Force";
            productToChange.Price = 110;
            warehouse.Categories.ViewAllCategories();
        }
        
        Console.WriteLine("Increasing quantity of product with id = 2");
        var productToAddQuantity = warehouse.Products.GetProduct(2);
        if (productToAddQuantity != null)
        {
            Console.WriteLine($"Before: {productToAddQuantity.Info()}");
            productToAddQuantity.ChangeQuantity(25);
            Console.WriteLine($"After: {productToAddQuantity.Info()}");
        }
        
        Console.WriteLine("Sorting list of products by name in ascending order");
        Console.WriteLine(warehouse.Products.Sort("name").Aggregate("\t", (s, product) => s + product + Environment.NewLine + "\t", s => s + Environment.NewLine));
        Console.WriteLine("Sorting list of products by a manufacturer in descending order");
        Console.WriteLine(warehouse.Products.Sort("manufacturer", false).Aggregate("\t", (s, product) => s + product + Environment.NewLine + "\t", s => s + Environment.NewLine));
        Console.WriteLine("Sorting list of products by a price in ascending order");
        Console.WriteLine(warehouse.Products.Sort("price").Aggregate("\t", (s, product) => s + product + Environment.NewLine + "\t", s => s + Environment.NewLine));
        
        Console.WriteLine("Adding new suppliers");
        var supplier1 = new Supplier("Mykola", "Zelenskyy", "mykolka@gmail.com");
        var supplier2 = new Supplier("Ivan", "Bulba", "i.bulba@gmail.com");
        var supplier3 = new Supplier("Andrii", "Osadchyk", "andrew.ua.22@gmail.com");
        var supplier4 = new Supplier("Anton", "Mbappe", "antonio@gmail.com");

        warehouse.Suppliers.AddSupplier(supplier1);
        warehouse.Suppliers.AddSupplier(supplier2);
        warehouse.Suppliers.AddSupplier(supplier3);
        warehouse.Suppliers.AddSupplier(supplier4);
        warehouse.Suppliers.PrintList();

        var supplier5 = new Supplier("Test", "Testovych", "test@gmail.com");
        warehouse.Suppliers.AddSupplier(supplier5);
        warehouse.Suppliers.PrintList();
        
        Console.WriteLine("Changing supplier data for id = 1");
        var supplierToChange = warehouse.Suppliers.GetSupplier(1);
        if (supplierToChange != null)
        {
            supplierToChange.Name = "Taras";
        }
        Console.WriteLine($"Changed supplier with id = 1: {supplierToChange}");
        
        Console.WriteLine("Sorting list of suppliers by name in ascending order");
        Console.WriteLine(warehouse.Suppliers.Sort("name").Aggregate("\t", (s, product) => s + product + Environment.NewLine + "\t", s => s + Environment.NewLine));
        Console.WriteLine("Sorting list of suppliers by surname in descending order");
        Console.WriteLine(warehouse.Suppliers.Sort("surname", false).Aggregate("\t", (s, product) => s + product + Environment.NewLine + "\t", s => s + Environment.NewLine));
        
        Console.WriteLine("Trying to search in products by keyword \"sc\"");
        Console.Write(warehouse.Products.Search("sc").Aggregate("\t", (s, product) => s + product + Environment.NewLine + "\t", s => s + Environment.NewLine));
        
        Console.WriteLine("Trying to search in products by keyword \"air\"");
        Console.Write(warehouse.Products.Search("air").Aggregate("\t", (s, product) => s + product + Environment.NewLine + "\t", s => s + Environment.NewLine));
        
        Console.WriteLine("Trying to search in suppliers by keyword \"an\"");
        Console.Write(warehouse.Suppliers.Search("an").Aggregate("\t", (s, product) => s + product + Environment.NewLine + "\t", s => s + Environment.NewLine));
        
        Console.WriteLine("Trying to search in suppliers by keyword \"zelen\"");
        Console.Write(warehouse.Suppliers.Search("zelen").Aggregate("\t", (s, product) => s + product + Environment.NewLine + "\t", s => s + Environment.NewLine));
        
        Console.WriteLine("---------");
        Console.Write(warehouse.Suppliers.Search("123123").Aggregate("\t", (s, product) => s + product + Environment.NewLine + "\t", s => s + Environment.NewLine));

        Console.ReadLine();
    }
}