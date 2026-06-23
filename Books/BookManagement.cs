using E_Library.Users;

namespace E_Library.Books
{
    public class BookManagement: IBookManagement
    {
        private readonly List<Book> _books;
        private readonly IUserManagement _userManagement;
        public BookManagement(IUserManagement userManagement)
        {
            _books = new List<Book>();
            _userManagement = userManagement;
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
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
            }
        }
        public void DeleteBook(int id)
        {
            var u = _books.FirstOrDefault(x => x.Id == id);
            if (u != null)
            {
                _books.Remove(u);
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public void PrintBooks()
        {
            foreach (var book in _books)
            {
                Console.WriteLine("ID:{0}\tTitle:{1}\tAuthor:{2}\tISBN:{3}\tCategory:{4}", book.Id, book.Title, book.Author, book.ISBN, book.Category);
            }
        }

        public void TrackLoanStatus()
        {
            foreach (var book in _books.Where(x => x.BorrowedByUserId > 0))
            {
                var user = _userManagement.GetUserById(book.BorrowedByUserId);
                if (user != null)
                {
                    Console.WriteLine($"ID:{book.Id}\tBook:{book.Title}\tBorrower:{user.Name}\tDue Date:{book.DueDate}\tOverdue:{ (book.DueDate < DateTime.Now) }");
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
    }
}