using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class ResultRepository : IRepository<TestResult>
    {
        private static ResultRepository _instance;

        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "results.json");
        private List<TestResult> _results;

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

        public List<TestResult> LoadData()
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

        public void SaveData()
        {
            string json = JsonSerializer.Serialize(_results, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public List<TestResult> GetAll()
        {
            _results = LoadData();
            return _results;
        }

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
