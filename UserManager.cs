using System.Collections.Generic;

namespace Kodanalys
{
    class UserManager
    {
        private List<string> users = new List<string>();
        private const int MaxUsers = 10;

        public bool AddUser(string name)
        {
            if (users.Count >= MaxUsers)
                return false;

            users.Add(name);
            return true;
        }

        public List<string> GetUsers()
        {
            return new List<string>(users);
        }

        public bool RemoveUser(string name)
        {
            return users.Remove(name);
        }

        public bool UserExists(string name)
        {
            return users.Contains(name);
        }
    }
}
