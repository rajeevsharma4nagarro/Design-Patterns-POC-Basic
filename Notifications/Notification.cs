using E_Library.Users;

namespace E_Library.Notifications
{
    public sealed class Notification
    {
        private readonly List<IUserObserver> _observers = new();
        public void Subscribe(IUserObserver observer)
        {
            if (!_observers.Contains(observer)) _observers.Add(observer);
        }

        public void Unsubscribe(IUserObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyAll(string message)
        {
            foreach (var obs in _observers)
            {
                obs.Notify(message);
            }
        }
    }
}
