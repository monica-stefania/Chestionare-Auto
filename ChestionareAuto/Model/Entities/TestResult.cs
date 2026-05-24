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
    public class TestResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
        public TipSesiune SessionType { get; set; }
        public StareTest State { get; set; }
        public QuizMemento DateSalvate { get; set; }
        public TestResult() { }
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
        public bool IsPassed()
        {
            return State == StareTest.Admis;
        }
    }
}
