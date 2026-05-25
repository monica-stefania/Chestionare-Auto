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

    /// <summary>
    /// Implementează șablonul de proiectare Memento pentru salvarea și
    /// restaurarea stării unui chestionar.
    /// </summary>
    public class QuizMemento
    {
        /// <summary>
        /// Indexul întrebării curente la momentul salvării.
        /// </summary>
        public int CurrentIndex { get; set; }

        /// <summary>
        /// Numărul de greșeli acumulate la momentul salvării.
        /// </summary>
        public int NumberOfMistakes { get; set; }

        /// <summary>
        /// Numărul de răspunsuri corecte la momentul salvării.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Timpul rămas din sesiune la momentul salvării.
        /// </summary>
        public TimeSpan TimeRemained { get; set; }

        /// <summary>
        /// Lista completă de întrebări ale chestionarului, în ordinea în care
        /// au fost generate, pentru a putea fi restaurate identic.
        /// </summary>
        public List<Question> Questions { get; set; }

        /// <summary>
        /// Tipul sesiunii salvate (Examen sau Invatare), necesar pentru a
        /// reconstrui strategia corectă la restaurare.
        /// </summary>
        public TipSesiune SessionType { get; set; }

        /// <summary>
        /// Constructor implicit.
        /// Inițializează lista de întrebări ca listă goală.
        /// </summary>
        public QuizMemento()
        {
            Questions = new List<Question>();
        }

        /// <summary>
        /// Creează un Memento cu starea completă a unui chestionar la un moment dat.
        /// </summary>
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