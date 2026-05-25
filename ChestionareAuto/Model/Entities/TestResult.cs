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
using Patterns;
namespace Entities
{
    /// <summary>
    /// Reprezintă rezultatul unui test susținut de un utilizator.
    /// Stochează scorul, starea, tipul sesiunii și, în cazul testelor nefinalizate,
    /// starea salvată a chestionarului prin șablonul Memento.
    /// </summary>
    public class TestResult
    {
        /// <summary>
        /// Identificatorul unic al rezultatului testului.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificatorul utilizatorului care a susținut testul.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Data și ora la care a fost susținut sau salvat testul.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Numărul de răspunsuri corecte obținute în test.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Tipul sesiunii.
        /// </summary>
        public TipSesiune SessionType { get; set; }

        /// <summary>
        /// Starea finală a testului.
        /// </summary>
        public StareTest State { get; set; }

        /// <summary>
        /// Starea salvată a chestionarului prin șablonul Memento.
        /// Este utilizat doar în cazul în care "StareTest" este "Nefinalizat",
        /// pentru a permite reluarea de unde s-a oprit.
        /// </summary>
        public QuizMemento DateSalvate { get; set; }

        /// <summary>
        /// Constructor implicit.
        /// </summary>
        public TestResult() { }

        /// <summary>
        /// Inițializează un nou rezultat de test cu toate proprietățile necesare.
        /// </summary>
        public TestResult(int id, int userId, DateTime date, int score, TipSesiune sessionType, StareTest state, QuizMemento dateSalvate = null)
        {
            Id = id;
            UserId = userId;
            Date = date;
            Score = score;
            SessionType = sessionType;
            State = state;
            DateSalvate = dateSalvate;
        }

        /// <summary>
        /// Verifică dacă testul a fost promovat.
        /// </summary>
        /// <returns>True dacă testul a fost promovat, altfel False.</returns>
        public bool IsPassed()
        {
            return State == StareTest.Admis;
        }
    }
}
