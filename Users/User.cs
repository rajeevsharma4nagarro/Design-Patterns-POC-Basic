using E_Library.Emums;
using E_Library.Notifications;
using E_Library.Utilities;

namespace E_Library.Users
{
    // Abstract class representing a user in the system.
    // Implements IUserObserver interface for notification purposes.
    public abstract class User : IUserObserver
    {
        public int Id { get; set; } = IdGenerator.NewId();
        public string Name { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        private readonly INotifyUser _notificationService;
        protected User(INotifyUser notificationService, string name)
        {
            _notificationService = notificationService;
            Name = name;
        }

        public virtual void Notify(string message)
        {
            _notificationService.Send(Name, message);
        }
    }
}
