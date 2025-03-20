namespace lab8;

public static class Program
{
    public static void Main()
    {
        // var cat = new Category("Cat");
        // var prod1 = new Product("Cat", cat, 45);
        // var prod2 = new Electronics("Poco", "Xiaomi", cat, 88, 60);
        // Console.WriteLine(cat);

        var ware = new Warehouse("Comfy");
        ware.AddCategory(new Category("Phones"));
        ware.AddCategory(new Category("Tablets"));
        ware.PrintCategories();
    }
}