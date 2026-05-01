using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public interface IQuestionRepository
    {
        List<Question> GetAllQuestions();
        List<Question> GetQuestionsByCategory(string category);
        List<Question> GetRandomQuestions(int count);
        Question GetQuestionById(int id);

        void AddQuestion(Question question);
        void UpdateQuestion(Question question);
        void DeleteQuestion(int id);
        
        
    }
}
