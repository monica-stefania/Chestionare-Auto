using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json; 
using Commons;
namespace Model
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly string _filePath = "questions.json";
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

        //implementare interfata IQuestionRepository
        public List<Question> GetAllQuestions()
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

        public void AddQuestion(Question question)
        {
            if(_questions.Any(q => q.Id == question.Id))
            {
                throw new ArgumentException($"A question with Id {question.Id} already exists.");
            }
            _questions.Add(question);
            SaveData();
        }

        public void UpdateQuestion(Question question)
        {
            int index = _questions.FindIndex(q => q.Id == question.Id);
            if (index == -1)
            {
                throw new ArgumentException($"No question found with Id {question.Id}.");
            }
            _questions[index] = question;
            SaveData();
        }

        public void DeleteQuestion(int id)
        {
            Question removeQuestion = GetQuestionById(id);
            if (removeQuestion == null)
            {
                throw new ArgumentException($"No question found with Id {id}.");
            }
            _questions.Remove(removeQuestion);
             SaveData();
        }
    }
}
