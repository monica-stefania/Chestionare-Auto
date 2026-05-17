using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Patterns
{
    public class QuizManager
    {
        private static QuizManager _instance;
        public User CurrentUser { get; set; }
        public Quiz ActiveQuiz { get; set; }
        public int ActiveResultId { get; set; } = 0;
        private QuizManager()
        {
        }
        public static QuizManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new QuizManager();
                }
                return _instance;
            }
        }
    }
}
