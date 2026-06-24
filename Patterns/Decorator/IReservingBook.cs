using E_Library.Books;

namespace E_Library.Patterns.Decorator
{
    public interface IReservingBook
    {
        Book ReserveBook(Book book);
        Book UnReserveBook(Book book);
    }
}
