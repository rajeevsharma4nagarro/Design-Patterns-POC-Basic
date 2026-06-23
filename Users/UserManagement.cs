namespace E_Library.Users
{
    public class UserManagement: IUserManagement
    {
        private readonly List<User> _users;

        public UserManagement()
        {
            _users = new List<User>();
        }
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User? GetUserById(int id)
        {
            var u = _users.FirstOrDefault(x => x.Id == id);
            if (u != null)
            {
                return u;
            }
            return null;
        }
        public void UpdateUser(User user)
        {
            var u = _users.FirstOrDefault(x => x.Id == user.Id);
            if (u != null)
            {
                _users.Remove(u);
                _users.Add(user);
            }
        }
        public void DeleteUser(int id)
        {
            var u = _users.FirstOrDefault(x=>x.Id == id);
            if(u != null) 
            { 
                _users.Remove(u);
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public void PrintUsers()
        {
            foreach (var user in _users)
            {
                Console.WriteLine("ID:{0}\tRole:{1}\tName:{2}", user.Id, user.Role, user.Name);
            }
        }
    }
}
