/**************************************************************************
 * *
 * File:        QuizManager.cs                                           *
 * Copyright:   (c) 2026, Luca Monica, Macovei Paul, Talmaciu Theodor    *              
 * Description: Această clasă implementează șablonul de proiectare       *
 *              Singleton pentru gestionarea stării globale a aplicației.*
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns;
using Entities;

namespace Logic
{
    /// <summary>
    /// Implementează șablonul de proiectare Singleton pentru gestionarea stării globale a aplicației.
    /// </summary>
    public class QuizManager
    {
        private static QuizManager _instance;

        /// <summary>
        /// Utilizatorul autentificat în prezent în aplicație.
        /// Este setat la login și resetat la null la delogare.
        /// </summary>
        public User CurrentUser { get; set; }

        /// <summary>
        /// Chestionarul activ în curs de desfășurare.
        /// Este setat la pornirea unui test nou sau la reluarea unuia salvat.
        /// </summary>
        public Quiz ActiveQuiz { get; set; }

        /// <summary>
        /// Id-ul rezultatului activ din repository.
        /// Valoarea 0 înseamnă că este un test nou (va fi adăugat).
        /// O valoare diferită de 0 înseamnă că este un test reluat.
        /// </summary>
        public int ActiveResultId { get; set; } = 0;
        private QuizManager()
        {
        }

        /// <summary>
        /// Lazy initialization a instanței singleton. 
        /// </summary>
        public static QuizManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new QuizManager();
                }
                return _instance;
            }
        }
    }
}
