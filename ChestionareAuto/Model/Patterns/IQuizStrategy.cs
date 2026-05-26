/**************************************************************************
 * *
 * File:        IQuizStrategy.cs                                         *
 * Copyright:   (c) 2026, Luca Monica, Macovei Paul, Talmaciu Theodor    *              
 * Description: Aceasta este interfața pentru clasele ExamenStrategy     *
 *              și PracticeStrategy.                                     *
 * Author:      Luca Monica                                              *
 * Proiect:     Chestionare Auto                                         *
                                         
 *                                                                       *
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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    /// <summary>
    /// Interfața pentru clasele ExamenStrategy și PracticeStrategy, care definesc regulile și comportamentul diferitelor tipuri de sesiuni de chestionare.
    /// </summary>
    public interface IQuizStrategy
    {
        bool ShowImmediateFeedback();
        bool HasTimeLimit();
        int GetTimeLimit();
        int GetMaximumMistakes();
    }
}
