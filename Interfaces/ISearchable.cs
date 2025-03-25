namespace lab8.Interfaces;

public interface ISearchable<T>
{
    List<T> Search(string keyword);
}