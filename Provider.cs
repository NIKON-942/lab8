namespace lab8;

public class Provider(string name, string surname, string email, Category category)
{
    public string Name { get; set; } = name;
    public string Surname { get; set; } = surname;
    public string Email { get; set; } = email;
    public Category Category { get; set; } = category;

    public override string ToString() => 
        $"Provider[name={Name}, surname={Surname}, email={Email}, category={Category.Name}]";
}