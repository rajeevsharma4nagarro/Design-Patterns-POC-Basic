using E_Library.Emums;
using E_Library.Notifications;

namespace E_Library.Users
{
    // Concrete Librarian class representing a user in the system.
    public class Librarian : User
    {
        public Librarian(INotifyUser notifyUser, string name) : base(notifyUser, name)
        {
            Role = UserRole.Librarian;
        }
    }
}
