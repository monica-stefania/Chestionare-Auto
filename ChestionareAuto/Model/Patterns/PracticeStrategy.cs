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