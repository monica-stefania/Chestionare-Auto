using Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class ExamenStrategy : IQuizStrategy
    {
        private const int TIME_LIMIT_SEC = 1800; // 30 minute
        private const int MAX_MISTAKES = 5;

        public bool ShowImmediateFeedback()
        {
            return false;
        }
        public bool HasTimeLimit()
        {
            return true;
        }
        public int GetTimeLimit()
        {
            return TIME_LIMIT_SEC;
        }

        public int GetMaximumMistakes()
        {
            return MAX_MISTAKES;
        }
    }
}
