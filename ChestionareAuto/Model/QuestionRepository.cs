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
    public class QuestionRepository : IRepository<Question>
    {
        // Adaugă sus: using System.IO;

        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "questions.json");
        private List<Question> _questions;
        public QuestionRepository()
        {
            _questions = LoadData();
        }

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
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data from {_filePath}: {ex.Message}");
                return new List<Question>();
            }
        }

        public void SaveData()
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(_questions, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data to {_filePath}: {ex.Message}");
            }
        }

        public List<Question> GetAll()
        {
            return _questions;
        }

        public List<Question> GetQuestionsByCategory(string category)
        {
            return _questions.Where(q => q.Category == category).ToList();
        }

        public List<Question> GetRandomQuestions(int count)
        {
            Random random = new Random();
            return _questions.OrderBy(q => random.Next()).Take(count).ToList();
        }

        public Question GetQuestionById(int id)
        {
            return _questions.FirstOrDefault(q => q.Id == id);
        }
        public void Add(Question entity)
        {
            // O mica logica sa ii dam un ID automat daca nu are
            if (!_questions.Any(q => q.Id == entity.Id))
            {
                entity.Id = _questions.Any() ? _questions.Max(q => q.Id) + 1 : 1;
            }

            _questions.Add(entity);
            SaveData();
        }

        public void Update(Question entity)
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

        public void Delete(Question entity)
        {
            var existingQuestion = _questions.FirstOrDefault(q => q.Id == entity.Id);
            if (existingQuestion != null)
            {
                _questions.Remove(existingQuestion);
                SaveData();
            }
        }
    }
}
