/**************************************************************************
 * *
 * File:        Question.cs                                              *
 * Copyright:   (c) 2026, Luca Monica, Macovei Paul, Talmaciu Theodor    *              
 * Description: Această clasă reprezintă modelul de date pentru o        *
 *              întrebare, conținând textul, variantele și imaginile.    *
 * Author:      Luca Monica, Macovei Paul, Talmaciu Theodor              *
 * Proiect:     Chestionare Auto                                         *
                                         
 * *
 * Acest software a fost dezvoltat de 3 studenți ca proiect educațional  *
 * și a fost conceput pentru a fi utilizat în mod gratuit de către       *
 * oricine dorește să învețe sau să se testeze pentru examenul auto.     *
 
 * Sunteți liberi să utilizați și să modificați acest cod sursă în       *
 * aplicațiile voastre, cu condiția să păstrați această notă de          *
 * copyright și autorii originali.                                       *
 *                                                                       *
 **************************************************************************/

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