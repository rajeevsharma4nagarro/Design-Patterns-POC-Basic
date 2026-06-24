using E_Library.Books;

namespace E_Library.Patterns.Command
{
    public class BookCreateCommandInvoker
    {
        private readonly IBookManagement _bookManagement;
        public BookCreateCommandInvoker(IBookManagement bookManagement)
        {
            _bookManagement = bookManagement;
        }
        public void execute(BookCreateCommand command)
        {
            var handler = new BookCreateHandler(_bookManagement);
            handler.Handle(command);
        }
    }
}
