using E_Library.Emums;
using E_Library.Utilities;

namespace E_Library.Books
{
    public class Book : IBook
    {
        public int Id { get; set; } = IdGenerator.NewId();
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public bool IsReserved { get; set; } = false;
        public BookCategory Category { get; set; }
        public int BorrowedByUserId { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
