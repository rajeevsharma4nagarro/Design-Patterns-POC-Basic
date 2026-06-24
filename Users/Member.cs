using E_Library.Emums;
using E_Library.Notifications;

namespace E_Library.Users
{
    // Concrete Member class representing a user in the system.
    public class Member : User
    {
        public Member(INotifyUser notifyUser, string name) : base(notifyUser, name)
        {
            Role = UserRole.Member;
        }
    }
}
