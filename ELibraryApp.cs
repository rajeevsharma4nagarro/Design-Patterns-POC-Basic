using E_Library.Books;
using E_Library.Emums;
using E_Library.Users;
using E_Library.Utilities;

namespace E_Library
{
    public class ELibraryApp
    {
        private readonly IBookManagement _bookManagement;
        private readonly IUserManagement _userManagement;
        private readonly UserFactory _userFactory;
        public ELibraryApp(IBookManagement bookManagement, IUserManagement userManagement, UserFactory userFactory)
        {
            _bookManagement = bookManagement;
            _userManagement = userManagement;
            _userFactory = userFactory;
        }

        public void Run()
        {
            Book? book = null;
            User? user = null;
            int userId, bookId;
            IEnumerable<Book> books = null;
            IEnumerable<User> users = null;

            #region Data Seed
            _userManagement.AddUser(_userFactory.CreateUser(UserRole.Librarian, "Rajeev"));
            _userManagement.AddUser(_userFactory.CreateUser(UserRole.Member, "Kumar"));
            _userManagement.AddUser(_userFactory.CreateUser(UserRole.Member, "Sharma"));

            _bookManagement.AddBook(
                new Book
                {
                    Title = "Professional C#",
                    Author = "Wrox",
                    ISBN = "1111-222-3333",
                    Category = BookCategory.Education,
                    BorrowedByUserId = 2,// Kumar borrowed this book
                    DueDate = DateTime.Now.AddDays(-1) // Due date set as past date to show Overdue
                }
                );
            _bookManagement.AddBook(
                new Book
                {
                    Title = "Wings of Fire",
                    Author = "A.P.J. Abdul Kalam",
                    ISBN = "4444-555-666",
                    Category = BookCategory.Novels,
                    BorrowedByUserId = 2,// Kumar borrowed this book
                    DueDate = DateTime.Now.AddDays(2) // DueDate in future
                }
                );
            _bookManagement.AddBook(
                new Book
                {
                    Title = "Ramayana",
                    Author = "Valmiki Ji",
                    ISBN = "777-8888-999",
                    Category = BookCategory.Novels
                }
                );
            #endregion

            char choice;
            do
            {
                choice = GlobalConsoleLogger.LogMessage();
                switch (choice)
                {
                    #region Books Actions
                    //Add Book
                    case 'A':
                        GlobalConsoleLogger.LogMessage("Add Book");
                        GlobalConsoleLogger.PromptMessage("Enter Book Title: ");
                        var NewTitle = Console.ReadLine() ?? "Default";
                        GlobalConsoleLogger.PromptMessage("Enter Book Author: ");
                        var NewAuthor = Console.ReadLine() ?? "Default";
                        GlobalConsoleLogger.PromptMessage("Enter Book ISBN: ");
                        var NewISBN = Console.ReadLine() ?? "Default";
                        GlobalConsoleLogger.PromptMessage("Enter Book Category 0 for Novels, 1 for Education: ");
                        BookCategory NewCategory = Console.ReadKey().KeyChar == '0' ? BookCategory.Novels : BookCategory.Education;
                        book = new Book { Title = NewTitle, Author = NewAuthor, ISBN = NewISBN, Category = NewCategory };
                        _bookManagement.AddBook(book);
                        break;
                    //Update Book
                    case 'U':
                        GlobalConsoleLogger.LogMessage("Update Book");
                        GlobalConsoleLogger.PromptMessage("Enter Book Id: ");
                        if (int.TryParse(Console.ReadLine(), out bookId))
                        {
                            GlobalConsoleLogger.PromptMessage("Enter Book Name: ");
                            var UpdatedBookTitle = Console.ReadLine() ?? "Default";
                            GlobalConsoleLogger.PromptMessage("Enter Book Category 0 for Novels, 1 for Education: ");
                            BookCategory UpdatedBookCat = Console.ReadKey().KeyChar == '0' ? BookCategory.Novels : BookCategory.Education;

                            book = _bookManagement.GetBookById(bookId);
                            if (book != null)
                            {
                                book.Title = UpdatedBookTitle;
                                book.Category = UpdatedBookCat;
                                _bookManagement.UpdateBook(book);
                            }
                            else
                            {
                                GlobalConsoleLogger.LogMessage("Book not found.");
                            }
                        }
                        else
                        {
                            GlobalConsoleLogger.LogMessage("Invalid Book ID to update Book!");
                        }
                        break;
                    //Delete Book
                    case 'D':
                        GlobalConsoleLogger.LogMessage("Delete Book");
                        GlobalConsoleLogger.PromptMessage("Enter Book Id: ");
                        if (int.TryParse(Console.ReadLine(), out bookId))
                        {
                            _bookManagement.DeleteBook(bookId);
                        }
                        else
                        {
                            GlobalConsoleLogger.LogMessage("Invalid Book ID to delete!");
                        }
                        break;
                    //View Books
                    case 'V':
                        GlobalConsoleLogger.LogMessage("View Books");
                        _bookManagement.PrintBooks();
                        break;
                    #endregion

                    #region Loan Processing
                    //Loan Processing Borrow Book
                    case 'B':
                        GlobalConsoleLogger.LogMessage("Loan Processing Borrow Book");
                        GlobalConsoleLogger.PromptMessage("Enter Book Id: ");
                        int.TryParse(Console.ReadLine(), out bookId);
                        book = _bookManagement.GetBookById(bookId);

                        GlobalConsoleLogger.PromptMessage("Enter User Id: ");
                        int.TryParse(Console.ReadLine(), out userId);
                        user = _userManagement.GetUserById(userId);

                        if (book != null && user != null && book.BorrowedByUserId == 0)
                        {
                            book.BorrowedByUserId = user.Id;
                            book.DueDate = DateTime.Now.AddMinutes(5);//borrow  limit for 5 minutes
                            _bookManagement.UpdateBook(book);
                            user.Notify($"You have borrowed the book '{book.Title}'. It is due on {book.DueDate}.");
                        }
                        else
                        {
                            GlobalConsoleLogger.LogMessage("This book already borrowed!");
                        }
                        break;
                    //Loan Processing Return Book
                    case 'R':
                        GlobalConsoleLogger.LogMessage("Loan Processing Return Book");
                        GlobalConsoleLogger.PromptMessage("Enter Book Id: ");
                        int.TryParse(Console.ReadLine(), out bookId);
                        book = _bookManagement.GetBookById(bookId);
                        if (book != null && book.BorrowedByUserId > 0)
                        {
                            user = _userManagement.GetUserById(book.BorrowedByUserId);
                            book.BorrowedByUserId = 0;
                            book.DueDate = null;
                            _bookManagement.UpdateBook(book);
                            if(user != null)
                            {
                                user.Notify($"You have returned the book '{book.Title}'. Thank you!");
                            }   
                        }
                        break;
                    //Track loan status and due dates
                    case 'T':
                        GlobalConsoleLogger.LogMessage("Track loan status and due dates");
                        _bookManagement.TrackLoanStatus();
                        break;

                    //Notify users about due dates and overdue books
                    case 'N':
                        GlobalConsoleLogger.LogMessage("Notify users about due dates and overdue books");
                        _bookManagement.NotifyUserForOverDue();
                        break;
                    #endregion

                    #region User actions
                    //Register User
                    case 'S':
                        GlobalConsoleLogger.LogMessage("Register User");
                        GlobalConsoleLogger.PromptMessage("Enter User Name: ");
                        var NewName = Console.ReadLine() ?? "Default";
                        GlobalConsoleLogger.PromptMessage("Enter User Type 0 for Librarian, 1 for Member: ");
                        UserRole NewRole = Console.ReadKey().KeyChar == '0' ? UserRole.Librarian : UserRole.Member;

                        user = _userFactory.CreateUser(NewRole, NewName);
                        _userManagement.AddUser(user);
                        break;
                    //Update User
                    case 'E':
                        GlobalConsoleLogger.LogMessage("Update User");
                        GlobalConsoleLogger.PromptMessage("Enter User Id: ");
                        if (int.TryParse(Console.ReadLine(), out userId))
                        {
                            user = _userManagement.GetUserById(userId);
                            if (user != null)
                            {
                                GlobalConsoleLogger.PromptMessage("Enter User Name: ");
                                var UpdatedName = Console.ReadLine() ?? "Default";
                                GlobalConsoleLogger.PromptMessage("Enter User Type 0 for Librarian, 1 for Member: ");
                                UserRole UpdatedRole = Console.ReadKey().KeyChar == '0' ? UserRole.Librarian : UserRole.Member;
                                user.Name = UpdatedName;
                                user.Role = UpdatedRole;
                                _userManagement.UpdateUser(user);
                            }
                            else
                            {
                                GlobalConsoleLogger.LogMessage("Invalid User ID to update User!");
                            }
                        }
                        else
                        {
                            GlobalConsoleLogger.LogMessage("Invalid User ID to update user!");
                        }
                        
                        break;
                    //Delete User
                    case 'P':
                        GlobalConsoleLogger.LogMessage("Delete User");
                        GlobalConsoleLogger.PromptMessage("Enter User Id: ");
                        if (int.TryParse(Console.ReadLine(), out userId))
                        {
                            _userManagement.DeleteUser(userId);
                        }
                        else
                        {
                            GlobalConsoleLogger.LogMessage("Invalid User ID to delete!");
                        }
                        break;
                    //List Users
                    case 'L':
                        GlobalConsoleLogger.LogMessage("List Users");
                        _userManagement.PrintUsers();
                        break;
                    #endregion

                    case 'X':
                        GlobalConsoleLogger.LogMessage("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        GlobalConsoleLogger.LogMessage("Invalid choice!");
                        break;
                }

                GlobalConsoleLogger.LogMessage("\nPress any key  to continue!");
                var t = Console.ReadLine();
            } while (choice != 'X');
        }
    }
}
