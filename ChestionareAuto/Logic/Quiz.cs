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
    public class Quiz
    {
        private IQuizStrategy _strategy;
        private List<Question> _questions;
        private int _currentIndex;
        private int _mistakes;
        private int _score;
        private TimeSpan _timeRemained;
        private TipSesiune _tipSesiune;

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

        public Quiz(QuizMemento memento)
        {
            RestoreState(memento);
        }
        public Question GetCurrentQuestion()
        {
            if (_currentIndex < _questions.Count)
                return _questions[_currentIndex];
            return null;
        }

        public bool HasNextQuestion()
        {
            return _currentIndex < _questions.Count - 1;
        }

        public void MoveToNextQuestion()
        {
            if (HasNextQuestion())
            {
                _currentIndex++;
            }
        }

        public void IncreaseScore()
        {
            _score++;
        }

        public void IncreaseMistakes()
        {
            _mistakes++;
        }

        public bool CanContinue()
        {
            return _mistakes < _strategy.GetMaximumMistakes();
        }

        public bool IsPassed()
        {
            return _score >= 22;
        }

        public QuizMemento SaveState()
        {
            return new QuizMemento(_currentIndex, _mistakes, _score, _timeRemained, _questions, _tipSesiune);
        }

        public void RestoreState(QuizMemento memento)
        {
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
