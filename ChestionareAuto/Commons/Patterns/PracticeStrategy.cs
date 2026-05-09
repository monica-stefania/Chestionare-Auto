using Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PracticeStrategy : IQuizStrategy
    {
        private const int NO_TIME_LIMIT = 0;

        public bool ShowImmediateFeedback()
        {
            return true;
        }

        public bool HasTimeLimit()
        {
            return false;
        }

        public int GetTimeLimit()
        {
            return NO_TIME_LIMIT;
        }

        public int GetMaximumMistakes()
        {
            return int.MaxValue;
        }
    }
}