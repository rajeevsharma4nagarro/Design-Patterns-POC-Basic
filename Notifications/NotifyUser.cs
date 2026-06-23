
namespace E_Library.Notifications
{
    public class NotifyUser: INotifyUser
    {
        private readonly AzureBusNotificationService _notificationService;
        public NotifyUser(AzureBusNotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public void Send(string recipient, string message) 
        { 
            _notificationService.SendTo(recipient, message);
        }
    }
}
