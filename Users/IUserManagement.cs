namespace E_Library.Users
{
    public interface IUserManagement
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User? GetUserById(int id);
        void PrintUsers();
    }
}
