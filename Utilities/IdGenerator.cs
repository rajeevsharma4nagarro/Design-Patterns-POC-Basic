namespace E_Library.Utilities
{
    public class IdGenerator
    {
        private static int _currentId = 0;
        public static int NewId()
        {
            return Interlocked.Increment(ref _currentId);
        }
    }
}
