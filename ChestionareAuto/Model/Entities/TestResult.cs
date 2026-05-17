using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns;
namespace Entities
{
    public class TestResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
        public TipSesiune SessionType { get; set; }
        public StareTest State { get; set; }
        public QuizMemento DateSalvate { get; set; }
        public TestResult() { }
        public TestResult(int id, int userId, DateTime date, int score, TipSesiune sessionType, StareTest state, QuizMemento dateSalvate = null)
        {
            Id = id;
            UserId = userId;
            Date = date;
            Score = score;
            SessionType = sessionType;
            State = state;
            DateSalvate = dateSalvate;
        }
        public bool IsPassed()
        {
            return State == StareTest.Admis;
        }
    }
}
