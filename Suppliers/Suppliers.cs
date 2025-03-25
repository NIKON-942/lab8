using lab8.Interfaces;

namespace lab8.Suppliers;

public class Suppliers : ISearchable<Supplier>, ISortable<Supplier>
{
    public readonly List<Supplier> SupplierList = [];

    public List<Supplier> Search(string keyword) => 
        SupplierList.Where(supp => supp.Name.ToLower().Contains(keyword.ToLower()) 
                                       || supp.Surname.ToLower().Contains(keyword.ToLower())).ToList();

    public List<Supplier> Sort(string criteria, bool ascending)
    {
        var result = criteria switch
        {
            "name" => SupplierList.OrderBy(supp => supp.Name).ToList(),
            "surname" => SupplierList.OrderBy(supp => supp.Surname).ToList(),
            _ => throw new ArgumentException("Invalid criteria")
        };

        if (!ascending)
            result.Reverse();

        return result;
    }
}