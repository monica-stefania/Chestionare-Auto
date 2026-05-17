using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json; 
using System.Diagnostics;
using System.Net.Http.Headers;
using Entities;

namespace Repositories
{
    public class UserRepository : IRepository<User>
    {

        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "users.json");
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

        public List<User> GetAll()
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

        public void Add(User entity)
        {
            _users.Add(entity);
            SaveData();
        }

        public void Delete(User entity)
        {
            var userExistent = _users.FirstOrDefault(u => u.Id == entity.Id);
            if (userExistent != null)
            {
                _users.Remove(userExistent);
                SaveData();
            }
        }

        public void Update(User entity)
        {
            var userExistent = _users.FirstOrDefault(u => u.Id == entity.Id);
            if (userExistent != null)
            {
                userExistent.Name = entity.Name;
                userExistent.Username = entity.Username;
                userExistent.Email = entity.Email;
                userExistent.Password = entity.Password;
                userExistent.Role = entity.Role;

                SaveData();
            }
        }
    }

}
