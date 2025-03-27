using lab8.Interfaces;

namespace lab8.SupplierClasses;

/// <summary>
/// Represents a collection of suppliers.
/// </summary>
public class Suppliers : ISearchable<Supplier>, ISortable<Suppliers>
{
    public List<Supplier> SupplierList = [];

    /// <summary>
    /// Searches for suppliers whose name or surname contains the specified keyword.
    /// </summary>
    /// <param name="keyword">The keyword to search for.</param>
    /// <returns>A list of suppliers that match the search criteria.</returns>
    public List<Supplier> Search(string keyword) => 
        SupplierList.Where(supp => supp.Name.ToLower().Contains(keyword.ToLower()) 
                                   || supp.Surname.ToLower().Contains(keyword.ToLower())).ToList();

    /// <summary>
    /// Sorts the list of suppliers based on the specified criteria.
    /// </summary>
    /// <param name="criteria">The criteria to sort by. Valid values: "name", "surname".</param>
    /// <param name="ascending">If set to <c>true</c>, the list is sorted in ascending order, otherwise descending order.</param>
    /// <returns>A sorted list of suppliers.</returns>
    /// <exception cref="ArgumentException">Thrown when an invalid criteria is provided.</exception>
    public Suppliers Sort(string criteria, bool ascending = true)
    {
        SupplierList = criteria switch
        {
            "name" => SupplierList.OrderBy(supp => supp.Name).ToList(),
            "surname" => SupplierList.OrderBy(supp => supp.Surname).ToList(),
            _ => throw new ArgumentException("Invalid criteria")
        };

        if (!ascending)
            SupplierList.Reverse();

        return this;
    }
    
    /// <summary>
    /// Prints list of all suppliers
    /// </summary>
    public void PrintList()
    {
        Console.WriteLine("List of suppliers");
        foreach (var supp in SupplierList)
            Console.WriteLine("\t" + supp);
    }
}