/**************************************************************************
 * *
 * File:        UserRepository.cs                                        *
 * Copyright:   (c) 2026, Luca Monica, Macovei Paul, Talmaciu Theodor    *              
 * Description: Această clasă gestionează operațiile CRUD pentru 
 *              utilizatori și interacțiunea cu fișierul users.json      *
 * Author:      Luca Monica, Macovei Paul, Talmaciu Theodor              *
 * Proiect:     Chestionare Auto                                         *
                                         
 * *
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
    /// Repository pentru gestionarea utilizatorilor, implementând operațiile CRUD și interacțiunea cu fișierul users.json.
    /// </summary>
    public class UserRepository : IRepository<User>
    {

        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "users.json");
        private List<User> _users;

        /// <summary>
        /// Constructor care încarcă utilizatorii din fișierul JSON la inițializarea repository-ului.
        /// </summary>
        public UserRepository()
        {
            _users = LoadData();
        }

        /// <summary>
        /// Încarcă utilizatorii din fișierul JSON și îi returnează ca o listă de obiecte User. Dacă fișierul nu există, returnează o listă goală.
        /// </summary>
        /// <returns></returns>
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
                throw new Exception($"Fișierul de utilizatori este corupt. Detalii: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Eroare fatală la încărcarea utilizatorilor: {ex.Message}");
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
                throw new Exception($"Nu s-au putut salva datele utilizatorului. Verificați permisiunile. Detalii: {ex.Message}");
            }
        }

        /// <summary>
        /// Returnează toți utilizatorii înregistrați
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Adaugă un nou utilizator în lista curentă și salvează modificările în fișierul JSON
        /// </summary>
        /// <param name="entity"></param>
        public void Add(User entity)
        {
            if(entity.Id == 0)
            {
                entity.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            }
            
            _users.Add(entity);
            SaveData();
        }

        /// <summary>
        /// Sterge un utilizator existent din lista curentă și salvează modificările în fișierul JSON
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(User entity)
        {
            var userExistent = _users.FirstOrDefault(u => u.Id == entity.Id);
            if (userExistent != null)
            {
                _users.Remove(userExistent);
                SaveData();
            }
        }

        /// <summary>
        /// Actualizează un utilizator existent în lista curentă și salvează modificările în fișierul JSON
        /// </summary>
        /// <param name="entity"></param>
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
