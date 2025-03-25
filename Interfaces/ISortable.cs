namespace lab8.Interfaces;

public interface ISortable<T>
{
    List<T> Sort(string criteria, bool ascending);
}