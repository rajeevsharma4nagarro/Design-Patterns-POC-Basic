namespace E_Library.Users
{
    // Observer interface for notifications
    public interface IUserObserver
    {
        void Notify(string message);
    }
}
