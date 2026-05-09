using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public interface IQuizStrategy
    {
        bool ShowImmediateFeedback();
        bool HasTimeLimit();
        int GetTimeLimit();
        int GetMaximumMistakes();
    }
}
