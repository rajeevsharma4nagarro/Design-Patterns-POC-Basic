namespace E_Library.Notifications
{
    public interface INotifyUser
    {
        void Send(string recipient, string message);
    }
}
