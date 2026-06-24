using E_Library.Books;

namespace E_Library.Patterns.Decorator
{
    public class ReservingBook : IReservingBook
    {
        public Book ReserveBook(Book book)
        {
            book.IsReserved = true;
            return book;
        }

        public Book UnReserveBook(Book book)
        {
            book.IsReserved = false;
            return book;
        }
    }
}
