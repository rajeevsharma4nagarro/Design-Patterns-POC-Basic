

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
}
