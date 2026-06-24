using E_Library.Books;

namespace E_Library.Patterns.Iterators
{
    public class LoanIterator : CustomIterator<Book>
    {
        private int _index =  0;
        List<Book> _books;
        public LoanIterator(List<Book> books)
        {
            _books = books;
        }
        public bool HasNext()
        {
            return _index < _books.Count();
        }

        public Book Next()
        {
            return _books[_index++];
        }
    }
}
