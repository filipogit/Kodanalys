using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Kodanalys
{
    class UserManager
    {
        private List<string> users = new List<string>();
        private const int MaxUsers = 10;
        private const string FilePath = "users.json";

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

        public void SaveToFile()
        {
            File.WriteAllText(FilePath, JsonSerializer.Serialize(users));
        }

        public void LoadFromFile()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                users = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }
        }
    }
}
