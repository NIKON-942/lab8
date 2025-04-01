namespace lab8.CategoryClasses;

/// <summary>
/// Manages categories within a warehouse.
/// </summary>
public class Categories(Warehouse warehouse)
{
    private uint _nextCategoryId = 1;
    private readonly List<Category> _categoryList = [new ("Default")];
    
    /// <summary>
    /// Adds a new category to the warehouse.
    /// </summary>
    /// <param name="name">The name of the new category.</param>
    /// <returns>The ID of the added category.</returns>
    public uint AddCategory(string name) {
        var category = new Category(name) { Id = _nextCategoryId++ };
        _categoryList.Add(category);
        return category.Id;
    }
    
    /// <summary>
    /// Adds a new category to the warehouse.
    /// </summary>
    /// <param name="category">The category to add.</param>
    /// <returns>The ID of the added category.</returns>
    public uint AddCategory(Category category) {
        category.Id = _nextCategoryId++;
        _categoryList.Add(category);
        return category.Id;
    }
    
    /// <summary>
    /// Removes a category from the warehouse.
    /// </summary>
    /// <param name="id">The ID of the category to remove.</param>
    /// <exception cref="ArgumentException">Thrown when attempting to delete the default category.</exception>
    public void RemoveCategory(uint id) {
        if (id == 0)
            throw new ArgumentException("Can't delete Default category");
        var category = _categoryList.FirstOrDefault(cat => cat.Id == id);
        if (category == null)
            return;
        _categoryList.Remove(category);
        var productsFromCategory = warehouse.Products.GetAllProducts().Where(prod => prod.Category!.Id == id);
        foreach (var prod in productsFromCategory)
            prod.Category = _categoryList[0];
    }
    
    /// <summary>
    /// Updates the name of an existing category.
    /// </summary>
    /// <param name="id">The ID of the category to update.</param>
    /// <param name="newName">The new name for the category.</param>
    /// <returns>The ID of the updated category.</returns>
    /// <exception cref="ArgumentException">Thrown when the category does not exist.</exception>
    public uint UpdateCategory(uint id, string newName) {
        var category = _categoryList.FirstOrDefault(cat => cat.Id == id);
        if (category == null)
            throw new ArgumentException($"Category with id = {id} does not exist");
        category.Name = newName;
        return id;
    }
    
    /// <summary>
    /// Displays the details of a specific category and its products.
    /// </summary>
    /// <param name="id">The ID of the category to view.</param>
    /// <exception cref="ArgumentException">Thrown when the category does not exist.</exception>
    public void ViewCategory(uint id)
    {
        var category = _categoryList.FirstOrDefault(cat => cat.Id == id);
        if (category == null)
            throw new ArgumentException($"Category with id = {id} does not exist");
        Console.WriteLine($"{category}:");
        var products = warehouse.Products.GetAllProducts().Where(prod => prod.Category!.Id == id);
        foreach (var prod in products)
            Console.WriteLine("\t" + prod);
    }
    
    /// <summary>
    /// Displays all categories and their products.
    /// </summary>
    public void ViewAllCategories()
    {
        Console.WriteLine($"All categories ({warehouse.Name}):");
        foreach (var cat in _categoryList)
        {
            Console.WriteLine($"\t{cat}:");
            var products = warehouse.Products.GetAllProducts().Where(prod => prod.Category == cat);
            foreach (var prod in products)
                Console.WriteLine("\t\t" + prod);
        }
    }
    
    /// <summary>
    /// Retrieves a category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category to retrieve.</param>
    /// <returns>The category if found, otherwise null.</returns>
    public Category? GetCategoryById(uint id) =>
        _categoryList.FirstOrDefault(cat => cat.Id == id);

    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <returns>A list of all categories.</returns>
    public List<Category> GetAllCategories() =>
        _categoryList;
}