
namespace E_Library.Patterns.Iterators
{
    public interface CustomIterator<T> where T : class
    {
        bool HasNext();
        T Next();
    }
}
