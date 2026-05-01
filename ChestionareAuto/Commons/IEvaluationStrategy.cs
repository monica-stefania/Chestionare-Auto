using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public interface IEvaluationStrategy
    {
        int NumberOfQuestions { get; }
        int MaximMistakesAllowed { get; }
        bool ShowAnswers { get; }

        bool HasTimer { get; }
        int TimeLimitInSeconds { get; }
    }
}
