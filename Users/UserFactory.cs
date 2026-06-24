using E_Library.Emums;
using E_Library.Notifications;

namespace E_Library.Users
{
    //Concrete Factories User Class
    public class UserFactory
    {
        private readonly INotifyUser _notifyUser;
        public UserFactory(INotifyUser notifyUser)
        {
            _notifyUser = notifyUser;
        }
        public User CreateUser(UserRole role, string name)
        {
            return role switch
            {
                UserRole.Member => new Member(_notifyUser, name),
                UserRole.Librarian => new Librarian(_notifyUser, name),
                _ => throw new Exception("Unknown user role")
            };
        }
    }
}
