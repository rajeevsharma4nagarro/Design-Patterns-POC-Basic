using E_Library.Books;

namespace E_Library.Patterns.Command
{
    public class BookCreateHandler
    {
        private readonly IBookManagement _bookManagement;

        public BookCreateHandler(IBookManagement bookManagement)
        {
            _bookManagement = bookManagement;
        }

        public void Handle(BookCreateCommand command)
        {
            var newBook = new Book
            {
                Id = command.Id,
                Title = command.Title,
                Author = command.Author,
                ISBN = command.ISBN
            };
            _bookManagement.AddBook(newBook);
        }
    }
}
