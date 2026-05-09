using Entities;
namespace Patterns
{
    public class QuizMemento
    {
        public int CurrentIndex { get; set; }
        public int NumberOfMistakes { get; set; }
        public int Score { get; set; }
        public TimeSpan TimeRemained { get; set; }
        public List<Question> Questions { get; set; }
        public TipSesiune SessionType { get; set; }

        public QuizMemento()
        {
            Questions = new List<Question>();
        }

        public QuizMemento(int currentIndex, int numberOfMistakes, int score, TimeSpan timeRemained, List<Question> questions, TipSesiune tipSesiune)
        {
            CurrentIndex = currentIndex;
            NumberOfMistakes = numberOfMistakes;
            Score = score;
            TimeRemained = timeRemained;
            Questions = questions;
            SessionType = tipSesiune;
        }
    }
}