namespace lab8.Interfaces;

public interface ISortable<T>
{
    T Sort(string criteria, bool ascending);
}