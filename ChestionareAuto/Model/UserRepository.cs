using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json; 
using Commons;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Model
{
    public class UserRepository : IUserRepository
    {
        private readonly string _filePath = "users.json";
        private List<User> _users;

        public UserRepository()
        {
            _users = LoadData();
        }

        public List<User> LoadData()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string jsonData = File.ReadAllText(_filePath);
                    return JsonSerializer.Deserialize<List<User>>(jsonData) ?? new List<User>();
                }
                else
                {
                    return new List<User>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data from {_filePath}: {ex.Message}");
                return new List<User>();
            }
        }

        public void SaveData()
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data to {_filePath}: {ex.Message}");
            }
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public void AddUser(User user)
        {
            if (GetUserByUsername(user.Username) != null)
            {
                throw new Exception("Username already exists.");
            }

            if (user.Id == 0)
            {
                user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            }

            _users.Add(user);
            SaveData();
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _users.Remove(user);
                SaveData();
            }
            else
            {
                throw new Exception("User not found.");
            }
        }

        public void UpdateUser(User user)
        {
            var existingUser = GetUserById(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                SaveData();
            }
            else
            {
                throw new Exception("User not found.");
            }
        }

        public bool ValidateUser(string username, string password)
        {
            var user = GetUserByUsername(username);
            return user != null && user.Password == password;
        }
    }

}
