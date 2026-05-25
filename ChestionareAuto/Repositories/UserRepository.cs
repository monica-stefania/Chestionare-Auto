/**************************************************************************
 * *
 * File:        UserRepository.cs                                        *
 * Copyright:   (c) 2026, Luca Monica, Macovei Paul, Talmaciu Theodor    *              
 * Description: Această clasă este un Repository Singleton pentru        *
 *              gestionarea userilor aplicației.                         *
 * Author:      Talmaciu Theodor                                         *
 * Proiect:     Chestionare Auto                                         *
                                         
 *                                                                       *
 * Acest software a fost dezvoltat de 3 studenți ca proiect educațional  *
 * și a fost conceput pentru a fi utilizat în mod gratuit de către       *
 * oricine dorește să învețe sau să se testeze pentru examenul auto.     *
 
 * Sunteți liberi să utilizați și să modificați acest cod sursă în       *
 * aplicațiile voastre, cu condiția să păstrați această notă de          *
 * copyright și autorii originali.                                       *
 *                                                                       *
 **************************************************************************/

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
    /// <summary>
    /// Repository Singleton pentru gestionarea utilizatorilor aplicației.
    /// Implementează operațiile CRUD și persistența datelor în fișierul users.json.
    /// </summary>
    public class UserRepository : IRepository<User>
    {

        private static UserRepository _instance;

        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "users.json");
        private List<User> _users;

        private UserRepository()
        {
            _users = LoadData();
        }

        /// <summary>
        /// Lazy initialization a instanței singleton. 
        /// </summary>
        public static UserRepository Instance()
        {
            if (_instance == null)
                _instance = new UserRepository();
            return _instance;
        }

        /// <summary>
        /// Încarcă utilizatorii din fișierul JSON și îi returnează ca o listă de obiecte User. Dacă fișierul nu există, returnează o listă goală.
        /// </summary>
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
            catch (JsonException ex)
            {
                Console.WriteLine($"Fișierul de utilizatori este malformat: {ex.Message}");
                return new List<User>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la încărcarea utilizatorilor: {ex.Message}");
                return new List<User>();
            }
        }

        /// <summary>
        /// Salvează lista curentă de utilizatori în fișierul JSON
        /// </summary>
        public void SaveData()
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nu s-au putut salva datele utilizatorului: {ex.Message}");
            }
        }

        /// <summary>
        /// Returnează toți utilizatorii înregistrați
        /// </summary>
        public List<User> GetAll()
        {
            return _users;
        }

        /// <summary>
        /// Caută un utilizator după identificatorul său unic.
        /// </summary>
        /// <param name="id">Id-ul utilizatorului căutat.</param>
        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Caută un utilizator după numele de utilizator.
        /// </summary>
        public User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Adaugă un nou utilizator în lista curentă și salvează modificările în fișierul JSON.
        /// </summary>
        /// <param name="entity">Utilizatorul de adăugat.</param>
        public void Add(User entity)
        {
            try
            {
                if (entity.Id == 0)
                {
                    entity.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
                }

                _users.Add(entity);
                SaveData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nu s-a putut adăuga utilizatorul: {ex.Message}");
            }
        }

        /// <summary>
        /// Sterge un utilizator existent din lista curentă și salvează modificările în fișierul JSON.
        /// </summary>
        /// <param name="entity">Utilizatorul de șters.</param>
        public void Delete(User entity)
        {
            try
            {
                var userExistent = _users.FirstOrDefault(u => u.Id == entity.Id);
                if (userExistent != null)
                {
                    _users.Remove(userExistent);
                    SaveData();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Nu s-a putut șterge utilizatorul: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualizează un utilizator existent în lista curentă și salvează modificările în fișierul JSON.
        /// </summary>
        /// <param name="entity">Utilizatorul căruia trebuie să i se actualizeze informațiile.</param>
        public void Update(User entity)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Nu s-a putut da update la datele utilizatorului: {ex.Message}");
            }
        }
    }

}
