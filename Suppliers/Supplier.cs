namespace lab8.Suppliers;

public class Supplier(string name, string surname, string email)
{
    public uint Id { get; set; } 
    public string Name { get; set; } = name;
    public string Surname { get; set; } = surname;
    public string Email { get; set; } = email;

    public string Info() => 
        $"Supplier[name={Name}, surname={Surname}, email={Email}]";
}