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

using Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{

    /// <summary>
    /// Implementarea strategiei pentru sesiunile de tip Examen.
    /// </summary>
    public class ExamenStrategy : IQuizStrategy
    {
        private const int TIME_LIMIT_SEC = 1800; // 30 minute
        private const int MAX_MISTAKES = 5;

        /// <summary>
        /// La examen nu se afișează feedback imediat, utilizatorul vede rezultatele abia la finalul testului.
        /// </summary>
        /// <returns>False, deoarece feedback-ul imediat nu este permis la examen.</returns>
        public bool ShowImmediateFeedback()
        {
            return false;
        }

        /// <summary>
        /// Examenul are o limită de timp de 30 de minute.
        /// </summary>
        /// <returns>True, deoarece examenul are o limită de timp.</returns>
        public bool HasTimeLimit()
        {
            return true;
        }

        /// <summary>
        /// Returnează durata maximă a examenului.
        /// </summary>
        /// <returns>1800 secunde (30 de minute).</returns>
        public int GetTimeLimit()
        {
            return TIME_LIMIT_SEC;
        }

        /// <summary>
        /// Returnează numărul maxim de greșeli permise la examen.
        /// </summary>
        /// <returns>5 greșeli maxim.</returns>
        public int GetMaximumMistakes()
        {
            return MAX_MISTAKES;
        }
    }
}
