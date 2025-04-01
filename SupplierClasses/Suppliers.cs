using lab8.Interfaces;

namespace lab8.SupplierClasses;

/// <summary>
/// Represents a collection of suppliers.
/// </summary>
public class Suppliers : ISearchable<Supplier>, ISortable<Supplier>
{
    private uint _nextSupplierId;
    private readonly List<Supplier> _supplierList = [];

    /// <summary>
    /// Adds a new supplier to the warehouse.
    /// </summary>
    /// <param name="newSupplier">The supplier to add.</param>
    /// <returns>The ID of the added supplier.</returns>
    public uint AddSupplier(Supplier newSupplier)
    {
        _supplierList.Add(newSupplier);
        newSupplier.Id = _nextSupplierId++;
        return newSupplier.Id;
    }
    
    /// <summary>
    /// Removes a supplier from the warehouse.
    /// </summary>
    /// <param name="suppId">The ID of the supplier to remove.</param>
    public void RemoveSupplier(uint suppId)
    {
        var supplier = _supplierList.FirstOrDefault(supp => supp.Id == suppId);
        if (supplier != null)
            _supplierList.Remove(supplier);
    }
    
    /// <summary>
    /// Searches for suppliers whose name or surname contains the specified keyword.
    /// </summary>
    /// <param name="keyword">The keyword to search for.</param>
    /// <returns>A list of suppliers that match the search criteria.</returns>
    public List<Supplier> Search(string keyword) => 
        _supplierList.Where(supp => supp.Name.ToLower().Contains(keyword.ToLower()) 
                                         || supp.Surname.ToLower().Contains(keyword.ToLower())).ToList();

    /// <summary>
    /// Sorts the list of suppliers based on the specified criteria.
    /// </summary>
    /// <param name="criteria">The criteria to sort by. Valid values: "name", "surname".</param>
    /// <param name="ascending">If set to <c>true</c>, the list is sorted in ascending order, otherwise descending order.</param>
    /// <returns>A sorted list of suppliers.</returns>
    /// <exception cref="ArgumentException">Thrown when an invalid criteria is provided.</exception>
    public List<Supplier> Sort(string criteria, bool ascending = true)
    {
        var result = criteria switch
        {
            "name" => _supplierList.OrderBy(supp => supp.Name).ToList(),
            "surname" => _supplierList.OrderBy(supp => supp.Surname).ToList(),
            _ => throw new ArgumentException("Invalid criteria")
        };

        if (!ascending)
            result.Reverse();

        return result;
    }
    
    /// <summary>
    /// Prints list of all suppliers
    /// </summary>
    public void PrintList()
    {
        Console.WriteLine("List of suppliers:");
        foreach (var supp in _supplierList)
            Console.WriteLine("\t" + supp);
    }
    
    /// <summary>
    /// Retrieves a supplier by its ID.
    /// </summary>
    /// <param name="id">The ID of the supplier.</param>
    /// <returns>The supplier if found, otherwise null.</returns>
    public Supplier? GetSupplier(uint id) =>
        _supplierList.FirstOrDefault(supp => supp.Id == id);

    /// <summary>
    /// Retrieves all suppliers.
    /// </summary>
    public List<Supplier> GetAllSuppliers() =>
        _supplierList;
}