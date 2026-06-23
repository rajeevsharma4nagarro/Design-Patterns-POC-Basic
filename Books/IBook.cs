using E_Library.Emums;

namespace E_Library.Books
{
    public interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        string ISBN { get; set; }
        BookCategory Category { get; set; }
    }
}
