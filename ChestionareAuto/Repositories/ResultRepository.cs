/**************************************************************************
 * *
 * File:        ResultRepository.cs                                              *
 * Copyright:   (c) 2026, Luca Monica, Macovei Paul, Talmaciu Theodor    *              
 * Description: Această clasă gestionează operațiile CRUD pentru 
 *              rezultatele testelor și interacțiunea cu fișierul results.json      *
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
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    /// <summary>
    /// Repository pentru gestionarea rezultatelor testelor, implementând operațiile CRUD și interacțiunea cu fișierul results.json.
    /// </summary>
    public class ResultRepository : IRepository<TestResult>
    {
        private static ResultRepository _instance;

        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "results.json");
        private List<TestResult> _results;

        /// <summary>
        /// Constructor care încarcă rezultatele testelor din fișierul JSON la inițializarea repository-ului.
        /// </summary>
        private ResultRepository()
        {
            _results = LoadData();
        }

        public static ResultRepository Instance()
        {
            if (_instance == null)
                _instance = new ResultRepository();
            return _instance;
        }

        /// <summary>
        /// Incarcă rezultatele testelor din fișierul JSON. Dacă fișierul nu există sau este gol, returnează o listă goală.
        /// </summary>
        /// <returns></returns>
        public List<TestResult> LoadData()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<TestResult>();
                }

                string json = File.ReadAllText(_filePath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<TestResult>();
                }

                return JsonSerializer.Deserialize<List<TestResult>>(json) ?? new List<TestResult>();
            }
            catch (JsonException ex)
            {
                throw new Exception($"Fișierul cu rezultate este malformat. Detalii: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Eroare fatală la citirea rezultatelor: {ex.Message}");
            }
        }

        /// <summary>
        /// Salvează lista curentă de rezultate în fișierul JSON
        /// </summary>
        public void SaveData()
        {
            try
            {
                string directory = Path.GetDirectoryName(_filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string json = JsonSerializer.Serialize(_results, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Nu s-au putut salva rezultatele. Verificați permisiunile de scriere. Detalii: {ex.Message}");
            }
        }

        /// <summary>
        /// Returnează toate rezultatele testelor din repository, încărcându-le din fișierul JSON pentru a asigura că sunt actualizate.
        /// </summary>
        /// <returns></returns>
        public List<TestResult> GetAll()
        {
            _results = LoadData();
            return _results;
        }

        /// <summary>
        /// Adaugă un nou rezultat de test în repository, atribuindu-i un ID unic și salvându-l în fișierul JSON.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TestResult entity)
        {
            if (_results.Count == 0)
            {
                entity.Id = 1;
            }
            else
            {
                entity.Id = _results.Max(r => r.Id) + 1;
            }
            _results.Add(entity);
            SaveData();
        }

        /// <summary>
        /// Actualizeaza un rezultat de test
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TestResult entity)
        {
            var existingResult = _results.FirstOrDefault(r => r.Id == entity.Id);
            if (existingResult != null)
            {
                existingResult.UserId = entity.UserId;
                existingResult.Date = entity.Date;
                existingResult.Score = entity.Score;
                existingResult.SessionType = entity.SessionType;
                existingResult.State = entity.State;
                existingResult.DateSalvate = entity.DateSalvate; // Asta e "cutia" Memento care se actualizeaza!

                SaveData();
            }
        }

        /// <summary>
        /// Sterge un rezultat de test
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TestResult entity)
        {
            var existingResult = _results.FirstOrDefault(r => r.Id == entity.Id);
            if (existingResult != null)
            {
                _results.Remove(existingResult);
                SaveData();
            }
        }
    }
}
