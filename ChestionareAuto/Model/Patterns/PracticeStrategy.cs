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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    /// <summary>
    /// Implementarea strategiei pentru sesiunile de tip Învățare.
    /// </summary>
    public class PracticeStrategy : IQuizStrategy
    {
        private const int NO_TIME_LIMIT = 0;

        /// <summary>
        /// La sesiunile de învățare se afișează imediat care variante sunt
        /// corecte (verde) și care sunt greșite (roșu).
        /// </summary>
        /// <returns>True, deoarece feedback-ul imediat este permis în sesiunea de învățare.</returns>
        public bool ShowImmediateFeedback()
        {
            return true;
        }

        /// <summary>
        /// Sesiunile de învățare nu au limită de timp.
        /// </summary>
        /// <returns>False, deoarece sesiunea de învățare nu are limită de timp.</returns>
        public bool HasTimeLimit()
        {
            return false;
        }

        /// <summary>
        /// Returnează durata maximă a examenului.
        /// </summary>
        /// <returns>0 secunde deoarece este fără limită de timp.</returns>
        public int GetTimeLimit()
        {
            return NO_TIME_LIMIT;
        }

        /// <summary>
        /// Returnează numărul maxim de greșeli permise la examen.
        /// </summary>
        /// <returns>Returnează un număr foarte mare, practic număr de greșeli nelimitat.</returns>
        public int GetMaximumMistakes()
        {
            return int.MaxValue;
        }
    }
}