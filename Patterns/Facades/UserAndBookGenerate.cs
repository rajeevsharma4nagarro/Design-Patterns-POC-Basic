using E_Library.Books;
using E_Library.Emums;
using E_Library.Users;

namespace E_Library.Patterns.Facades
{
    public class UserAndBookGenerate
    {
        private readonly UserFactory _userFactory;
        private readonly IBookManagement _bookManagement;
        private readonly IUserManagement _userManagement;
        public UserAndBookGenerate(IBookManagement bookManagement, UserFactory userFactory, IUserManagement userManagement)
        {
            _bookManagement = bookManagement;
            _userFactory = userFactory;
            _userManagement = userManagement;
        }

        public void GenerateUsersAndBooks(UserRole userRole, string UserName, string BookTitle, string BookAuthor, string BookISBN, BookCategory BookCategory)
        {
            _userManagement.AddUser(_userFactory.CreateUser(userRole, UserName));
            _bookManagement.AddBook(new Book { Title = BookTitle, Author = BookAuthor, ISBN = BookISBN, Category = BookCategory });
        }
    }
}
