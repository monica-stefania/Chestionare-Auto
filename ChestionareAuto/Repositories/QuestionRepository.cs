/**************************************************************************
 * *
 * File:        Question.cs                                              *
 * Copyright:   (c) 2026, Luca Monica, Macovei Paul, Talmaciu Theodor    *              
 * Description: Această clasă reprezintă modelul de date pentru o        *
 *              întrebare, conținând textul, variantele și imaginile.    *
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

using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json; 
using System.Threading.Tasks;
namespace Repositories
{
    /// <summary>
    /// Repository Singleton pentru gestionarea întrebărilor aplicației.
    /// Implementează operațiile CRUD și persistența datelor în fișierul questions.json.
    /// </summary>
    public class QuestionRepository : IRepository<Question>
    {
        private static QuestionRepository _instance;

        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "questions.json");
        private List<Question> _questions;
        private QuestionRepository()
        {
            _questions = LoadData();
        }

        /// <summary>
        /// Lazy initialization a instanței singleton. 
        /// </summary>
        public static QuestionRepository Instance()
        {
            if (_instance == null)
                _instance = new QuestionRepository();
            return _instance;
        }

        /// <summary>
        /// Încarcă întrebările din fișierul JSON.
        /// </summary>
        public List<Question> LoadData()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string jsonData = File.ReadAllText(_filePath);
                    return JsonSerializer.Deserialize<List<Question>>(jsonData) ?? new List<Question>();
                }
                else
                {
                    return new List<Question>();
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Fișierul de întrebări este malformat: {ex.Message}");
                return new List<Question>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la încărcarea întrebărilor din {_filePath}: {ex.Message}");
                return new List<Question>();
            }
        }

        /// <summary>
        /// Salvează lista curentă de întrebări în fișierul JSON.
        /// </summary>
        public void SaveData()
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(_questions, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la salvarea întrebărilor în {_filePath}: {ex.Message}");
            }
        }

        /// <summary>
        /// Returnează toate întrebările din repository.
        /// </summary>
        public List<Question> GetAll()
        {
            return _questions;
        }

        /// <summary>
        /// Returnează toate întrebările dintr-o anumită categorie.
        /// </summary>
        public List<Question> GetQuestionsByCategory(string category)
        {
            return _questions.Where(q => q.Category == category).ToList();
        }

        /// <summary>
        /// Returnează un număr specificat de întrebări alese aleatoriu din toate categoriile.
        /// </summary>
        /// <param name="count">Numărul de întrebări de returnat.</param>
        public List<Question> GetRandomQuestions(int count)
        {
            Random random = new Random();
            return _questions.OrderBy(q => random.Next()).Take(count).ToList();
        }

        /// <summary>
        /// Caută și returnează o întrebare după identificatorul său unic.
        /// </summary>
        public Question GetQuestionById(int id)
        {
            return _questions.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Adaugă o nouă întrebare în repository și salvează modificările.
        /// Id-ul este generat automat dacă nu este setat sau este duplicat.
        /// </summary>
        /// <param name="entity">Întrebarea de adăugat.</param>
        public void Add(Question entity)
        {
            try
            {
                if (!_questions.Any(q => q.Id == entity.Id))
                {
                    entity.Id = _questions.Any() ? _questions.Max(q => q.Id) + 1 : 1;
                }

                _questions.Add(entity);
                SaveData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la adăugarea întrebării: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualizează o întrebare existentă (identificată după Id) cu noile date
        /// și salvează modificările în fișierul JSON.
        /// </summary>
        /// /// <param name="entity">Întrebarea careia trebuie să îi actualizăm datele.</param>
        public void Update(Question entity)
        {
            try
            {
                var existingQuestion = _questions.FirstOrDefault(q => q.Id == entity.Id);
                if (existingQuestion != null)
                {
                    existingQuestion.Text = entity.Text;
                    existingQuestion.Options = entity.Options;
                    existingQuestion.CorrectOptionsIndex = entity.CorrectOptionsIndex;
                    existingQuestion.Image = entity.Image;
                    existingQuestion.Category = entity.Category;

                    SaveData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la actualizarea întrebării: {ex.Message}");
            }
        }

        /// <summary>
        /// Șterge o întrebare din repository (identificată după Id)
        /// și salvează modificările în fișierul JSON.
        /// </summary>
        /// <param name="entity">Întrebarea de șters.</param>
        public void Delete(Question entity)
        {
            try
            {
                var existingQuestion = _questions.FirstOrDefault(q => q.Id == entity.Id);
                if (existingQuestion != null)
                {
                    _questions.Remove(existingQuestion);
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la ștergerea întrebării: {ex.Message}");
            }
        }

        /// <summary>
        /// Generează un set de 26 de întrebări pentru un test,
        /// preluând un număr specific de întrebări din fiecare categorie.
        /// </summary>
        public List<Question> GenereazaTestExamen()
        {
            var intrebariExamen = new List<Question>();

            // preluăm întrebări din fiecare 
            var legislatie = _questions.Where(q => q.Category == "legislatie").OrderBy(x => Guid.NewGuid()).Take(14).ToList();
            var indicatoare = _questions.Where(q => q.Category == "indicatoare").OrderBy(x => Guid.NewGuid()).Take(6).ToList();
            var conduita = _questions.Where(q => q.Category == "conduita_preventiva").OrderBy(x => Guid.NewGuid()).Take(3).ToList();
            var mecanica = _questions.Where(q => q.Category == "mecanica").OrderBy(x => Guid.NewGuid()).Take(2).ToList();
            var primAjutor = _questions.Where(q => q.Category == "prim_ajutor").OrderBy(x => Guid.NewGuid()).Take(1).ToList();

            intrebariExamen.AddRange(legislatie);
            intrebariExamen.AddRange(indicatoare);
            intrebariExamen.AddRange(conduita);
            intrebariExamen.AddRange(mecanica);
            intrebariExamen.AddRange(primAjutor);

            // Dacă nu avem 26, completăm cu întrebări din alte categorii
            if (intrebariExamen.Count < 26)
            {
                int deCompletat = 26 - intrebariExamen.Count;
                var idUriFolosite = intrebariExamen.Select(q => q.Id).ToList(); // Să nu le punem de 2 ori

                var completare = _questions.Where(q => !idUriFolosite.Contains(q.Id))
                                           .OrderBy(x => Guid.NewGuid())
                                           .Take(deCompletat)
                                           .ToList();

                intrebariExamen.AddRange(completare);
            }

            // Amestecăm ordinea finală 
            return intrebariExamen.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
