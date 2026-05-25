/**************************************************************************
 * *
 * File:        Quiz.cs                                              *
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
using Entities;
using Model;

namespace Patterns
{
    /// <summary>
    /// Reprezintă un chestionar activ, gestionând starea curentă a sesiunii.
    /// </summary>
    public class Quiz
    {
        private IQuizStrategy _strategy;
        private List<Question> _questions;
        private int _currentIndex;
        private int _mistakes;
        private int _score;
        private TimeSpan _timeRemained;
        private TipSesiune _tipSesiune;

        /// <summary>
        /// Inițializează un chestionar nou.
        /// </summary>
        /// <param name="strategy">Strategia care definește regulile sesiunii.</param>
        /// <param name="questions">Lista de întrebări generate pentru acest chestionar.</param>
        /// <param name="tipSesiune">Tipul sesiunii (Examen sau Invatare).</param>
        public Quiz(IQuizStrategy strategy, List<Question> questions, TipSesiune tipSesiune)
        {
            _strategy = strategy;
            _questions = questions;
            _tipSesiune = tipSesiune;
            _currentIndex = 0;
            _mistakes = 0;
            _score = 0;
            _timeRemained = TimeSpan.FromSeconds(strategy.GetTimeLimit());
        }

        /// <summary>
        /// Restaurează un chestionar dintr-un Memento salvat anterior.
        /// </summary>
        /// <param name="memento">Starea salvată a chestionarului.</param>
        public Quiz(QuizMemento memento)
        {
            RestoreState(memento);
        }

        /// <summary>
        /// Returnează întrebarea la care se află utilizatorul în prezent.
        /// </summary>
        /// <returns>Întrebarea curentă sau null dacă nu mai există alte întrebări.</returns>
        public Question GetCurrentQuestion()
        {
            if (_currentIndex < _questions.Count)
                return _questions[_currentIndex];
            return null;
        }
        
        /// <summary>
        /// Verifică dacă există o întrebare următoare în chestionar.
        /// </summary>
        /// <returns>True dacă există o întrebare următoare, altfel False.</returns>
        public bool HasNextQuestion()
        {
            return _currentIndex < _questions.Count - 1;
        }

        /// <summary>
        /// Avansează la întrebarea următoare dacă aceasta există.
        /// </summary>
        public void MoveToNextQuestion()
        {
            if (HasNextQuestion())
            {
                _currentIndex++;
            }
        }

        /// <summary>
        /// Incrementează scorul cu 1 la un răspuns corect.
        /// </summary>
        public void IncreaseScore()
        {
            _score++;
        }

        /// <summary>
        /// Incrementează contorul de greșeli cu 1 la un răspuns greșit.
        /// </summary>
        public void IncreaseMistakes()
        {
            _mistakes++;
        }

        /// <summary>
        /// Verifică dacă sesiunea poate continua, adică dacă numărul de
        /// greșeli nu a depășit limita permisă de strategie.
        /// </summary>
        public bool CanContinue()
        {
            return _mistakes < _strategy.GetMaximumMistakes();
        }

        /// <summary>
        /// Verifică dacă utilizatorul a promovat chestionarul.
        /// </summary>
        public bool IsPassed()
        {
            return _score >= 22;
        }

        /// <summary>
        /// Salvează starea curentă a chestionarului într-un obiect Memento.
        /// </summary>
        public QuizMemento SaveState()
        {
            return new QuizMemento(_currentIndex, _mistakes, _score, _timeRemained, _questions, _tipSesiune);
        }

        /// <summary>
        /// Restaurează starea chestionarului dintr-un Memento salvat anterior.
        /// Reconstruiește strategia corespunzătoare tipului de sesiune salvat.
        /// </summary>
        /// <param name="memento">Starea salvată din care se restaurează chestionarul.</param>
        public void RestoreState(QuizMemento memento)
        {
            if (memento == null)
                throw new ArgumentNullException("Memento-ul nu poate fi null la restaurare.");

            _tipSesiune = memento.SessionType;
            _currentIndex = memento.CurrentIndex;
            _mistakes = memento.NumberOfMistakes;
            _score = memento.Score;
            _timeRemained = memento.TimeRemained;
            _questions = memento.Questions;

            if (_tipSesiune == TipSesiune.Examen)
                _strategy = new ExamenStrategy();
            else
                _strategy = new PracticeStrategy();
        }
        public int Score => _score;
        public int Mistakes => _mistakes;
        public int CurrentIndex => _currentIndex;
        public int TotalQuestions => _questions.Count;
        public IQuizStrategy Strategy => _strategy;
        public TimeSpan TimeRemained
        {
            get => _timeRemained;
            set => _timeRemained = value;
        }
    }

}
