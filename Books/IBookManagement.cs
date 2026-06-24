namespace E_Library.Books
{
    public interface IBookManagement
    {
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        public List<Book> GetAllBooks();
        Book? GetBookById(int id);
        void PrintBooks();
        void TrackLoanStatus();
        void NotifyUserForOverDue();
        void BookReserveStatusUpdate(int id, char isReserve);
    }
}
