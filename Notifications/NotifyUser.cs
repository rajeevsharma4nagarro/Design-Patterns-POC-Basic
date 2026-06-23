
namespace E_Library.Notifications
{
    // Azure bus notification service external service
    public class AzureBusNotificationService
    {
        public void SendTo(string recipientName, string body)
        {
            Console.WriteLine($"Azure bus sending message to {recipientName}: {body}");
        }
    }

    public interface INotifyUser
    {
        void Send(string recipient, string message);
    }

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
