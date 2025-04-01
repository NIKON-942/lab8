namespace lab8.SupplierClasses;

/// <summary>
/// Represents a supplier with basic contact information.
/// </summary>
public class Supplier(string name, string surname, string email)
{
    public uint Id { get; internal set; } 
    public string Name { get; set; } = name;
    public string Surname { get; set; } = surname;
    public string Email { get; set; } = email;

    /// <summary>
    /// Returns a string containing the supplier's information.
    /// </summary>
    /// <returns>A formatted string with the supplier's name, surname and email.</returns>
    public override string ToString() =>
        $"({Id}) {Name} {Surname} - {Email}";
}