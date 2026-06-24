using E_Library.Patterns.Decorator;
using E_Library.Patterns.Iterators;
using E_Library.Users;
using E_Library.Utilities;
using Microsoft.VisualBasic.FileIO;

namespace E_Library.Books
{
    public class BookManagement: IBookManagement
    {
        private readonly List<Book> _books;
        private readonly IUserManagement _userManagement;
        private readonly IReservingBook _reservingBook;
        public BookManagement(IReservingBook reservingBook, IUserManagement userManagement)
        {
            _books = new List<Book>();
            _userManagement = userManagement;
            _reservingBook = reservingBook;
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
            GlobalConsoleLogger.LogMessage("Book added successfully.");
        }
        public Book? GetBookById(int id)
        {
            var b = _books.FirstOrDefault(x => x.Id == id);
            if (b != null)
            {
                return b;
            }
            return null;
        }

        public void UpdateBook(Book book)
        {
            var b = _books.FirstOrDefault(x => x.Id == book.Id);
            if (b != null)
            {
                _books.Remove(b);
                _books.Add(book);
                GlobalConsoleLogger.LogMessage("Book updated successfully.");
            }
            else
            {
                GlobalConsoleLogger.LogMessage("Invalid Book.");
            }
        }
        public void DeleteBook(int id)
        {
            var u = _books.FirstOrDefault(x => x.Id == id);
            if (u != null)
            {
                _books.Remove(u);
                GlobalConsoleLogger.LogMessage("Book deleted successfully.");
            }
            else
            {
                GlobalConsoleLogger.LogMessage("Invalid Book ID to delete!");
            }
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public void PrintBooks()
        {
            foreach (var book in _books)
            {
                Console.WriteLine("ID:{0}\tTitle:{1}\tAuthor:{2}\tISBN:{3}\tCategory:{4}\tIs Hold:{5}\tIs Borrowed:{6}", book.Id, book.Title, book.Author, book.ISBN, book.Category, book.IsReserved, book.BorrowedByUserId > 0);
            }
        }

        public void TrackLoanStatus()
        {
            var booksList = new LoanCollection(this);
            var iterator = booksList.GetLoanIterator();
            while (iterator.HasNext())
            {
                var book = iterator.Next();
                var user = _userManagement.GetUserById(book.BorrowedByUserId);
                if (user != null)
                {
                    Console.WriteLine($"ID:{book.Id}\tBook:{book.Title}\tBorrower:{user.Name}\tDue Date:{book.DueDate}\tOverdue:{(book.DueDate < DateTime.Now)}");
                }
            }
        }

        public void NotifyUserForOverDue()
        {
            foreach (var book in _books.Where(x => x.BorrowedByUserId > 0))
            {
                var user = _userManagement.GetUserById(book.BorrowedByUserId);
                if (user != null)
                {
                    if(book.DueDate < DateTime.Now)
                    {
                        user.Notify($"Your borrowed book '{book.Title}' is overdue. Please return it as soon as possible.");
                    }
                    else
                    {
                        user.Notify($"Your borrowed book '{book.Title}' is due on {book.DueDate}. Please return it on time.");
                    }
                }
            }
        }

        public void BookReserveStatusUpdate(int id, char option)
        {
            var book = _books.Where(x => x.Id == id).FirstOrDefault();
            if (book != null && book.BorrowedByUserId > 0)
            {
                GlobalConsoleLogger.LogMessage("Book is already borrowed by another user. Cannot reserve.");
            }
            else if (book != null && book.BorrowedByUserId == 0)
            {
                switch (option)
                {
                    case 'Y':
                        UpdateBook(_reservingBook.ReserveBook(book));
                        GlobalConsoleLogger.LogMessage($"Book {book.Title} is Reserved.");
                        break;
                    case 'N':
                        UpdateBook(_reservingBook.ReserveBook(book));
                        GlobalConsoleLogger.LogMessage($"Book {book.Title} is UnReserved.");
                        break;
                    default:
                        GlobalConsoleLogger.LogMessage("Invalid Option!");
                        break;
                }
            }
            else
            {
                GlobalConsoleLogger.LogMessage("Book not found.");
            }
        }
    }
}