using Entities;
using Logic;
using Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_ChestionareAuto
{
    [TestClass]
    public class QuizTests
    {
        private List<Question> CreazaIntrebari(int numar = 26)
        {
            var lista = new List<Question>();
            for (int i = 0; i < numar; i++)
                lista.Add(new Question(i + 1, $"Întrebare {i + 1}?",
                    new List<string> { "A", "B", "C" },
                    new List<int> { 0 }, "", "General"));
            return lista;
        }

        
        //returneaza intrebarea de unde s-a ramas in chestionar din lista 
        [TestMethod]
        public void Test_GetCurrentQuestion()
        {
            var intrebari = CreazaIntrebari(5);
            var quiz = new Quiz(new ExamenStrategy(), intrebari, TipSesiune.Examen);

            var curent = quiz.GetCurrentQuestion();

            Assert.IsNotNull(curent);
            Assert.AreEqual(1, curent.Id);
        }

        //returneaza intrebarea de unde s-a ramas in chestionar din lista(null cand nu e nicio intrebare in lista)
        [TestMethod]
        public void Test_GetCurrentQuestion_EmptyList()
        {
            var quiz = new Quiz(new ExamenStrategy(), new List<Question>(), TipSesiune.Examen);
            Assert.IsNull(quiz.GetCurrentQuestion());
        }

        
        //returneaza true daca mai exista intrebari in lista dupa indexul curent si false daca nu 
        [TestMethod]
        public void Test_HasNextQuestion_RetTrue()
        {
            var quiz = new Quiz(new ExamenStrategy(), CreazaIntrebari(3), TipSesiune.Examen);
            Assert.IsTrue(quiz.HasNextQuestion());
        }

        [TestMethod]
        public void Test_HasNextQuestion_RetFalse()
        {
            var quiz = new Quiz(new ExamenStrategy(), CreazaIntrebari(1), TipSesiune.Examen);
            Assert.IsFalse(quiz.HasNextQuestion());
        }

        //avanseaza indexul intrebarii la care ai ramas
        [TestMethod]
        public void Test_MoveToNextQuestion()
        {
            var quiz = new Quiz(new ExamenStrategy(), CreazaIntrebari(5), TipSesiune.Examen);
            Assert.AreEqual(0, quiz.CurrentIndex);

            quiz.MoveToNextQuestion();

            Assert.AreEqual(1, quiz.CurrentIndex);
        }

        //nu se avanseaza la urmatoarea intrebare pentru ca nu mai sunt altele, astfel indexul curent ramane 0
        [TestMethod]
        public void Test_MoveToNextQuestion_NuAvanseaza()
        {
            var quiz = new Quiz(new ExamenStrategy(), CreazaIntrebari(1), TipSesiune.Examen);
            quiz.MoveToNextQuestion(); 

            Assert.AreEqual(0, quiz.CurrentIndex);
        }

        
        //verificam daca se mareste scorul daca raspunzi corect
        [TestMethod]
        public void Test_IncreaseScore()
        {
            var quiz = new Quiz(new PracticeStrategy(), CreazaIntrebari(5), TipSesiune.Invatare);
            Assert.AreEqual(0, quiz.Score);

            quiz.IncreaseScore();
            quiz.IncreaseScore();

            Assert.AreEqual(2, quiz.Score);
        }

        //verificam daca se mareste numarul de greseli
        [TestMethod]
        public void Test_IncreaseMistakes()
        {
            var quiz = new Quiz(new ExamenStrategy(), CreazaIntrebari(5), TipSesiune.Examen);
            Assert.AreEqual(0, quiz.Mistakes);

            quiz.IncreaseMistakes();
            quiz.IncreaseMistakes();

            Assert.AreEqual(2, quiz.Mistakes);
        }

        //returneaza true daca numarul de greseli e mai mic ca 5
        [TestMethod]
        public void Test_CanContinue_RetTrue()
        {
            var quiz = new Quiz(new ExamenStrategy(), CreazaIntrebari(26), TipSesiune.Examen);
            Assert.IsTrue(quiz.CanContinue());
        }

        [TestMethod]
        public void Test_CanContinue_RetFalse()
        {
            var quiz = new Quiz(new ExamenStrategy(), CreazaIntrebari(26), TipSesiune.Examen);
            // Adaugăm exact 5 greseli (limita)
            for (int i = 0; i < 5; i++)
                quiz.IncreaseMistakes();

            Assert.IsFalse(quiz.CanContinue());
        }

        [TestMethod]
        public void Test_CanContinue_Mediu_Invatare()
        {
            var quiz = new Quiz(new PracticeStrategy(), CreazaIntrebari(5), TipSesiune.Invatare);
            // Adăugăm 100 de greseli pentru ca la invatare nu conteaza
            for (int i = 0; i < 100; i++)
                quiz.IncreaseMistakes();

            Assert.IsTrue(quiz.CanContinue());
        }

        //daca avem mai mult sau egal de 22 de raspunsuri corecte, starea testului e admis
        [TestMethod]
        public void Test_IsPassed_RetTrue()
        {
            var quiz = new Quiz(new ExamenStrategy(), CreazaIntrebari(26), TipSesiune.Examen);
            for (int i = 0; i < 22; i++)
                quiz.IncreaseScore();

            Assert.IsTrue(quiz.IsPassed());
        }

        [TestMethod]
        public void Test_IsPassed_RetFalse()
        {
            var quiz = new Quiz(new ExamenStrategy(), CreazaIntrebari(26), TipSesiune.Examen);
            for (int i = 0; i < 21; i++)
                quiz.IncreaseScore();

            Assert.IsFalse(quiz.IsPassed());
        }

        //verificam timpul ramas la inceperea testului de tip examen (30 de minute)
        [TestMethod]
        public void Test_TimeRemained_Examen()
        {
            var quiz = new Quiz(new ExamenStrategy(), CreazaIntrebari(5), TipSesiune.Examen);
            Assert.AreEqual(TimeSpan.FromSeconds(1800), quiz.TimeRemained);
        }

        //timp nelimitat la testul de tip invatare
        [TestMethod]
        public void Test_TimeRemained_Invatare()
        {
            var quiz = new Quiz(new PracticeStrategy(), CreazaIntrebari(5), TipSesiune.Invatare);
            Assert.AreEqual(TimeSpan.Zero, quiz.TimeRemained);
        }

        //numarul total de intrebari dintr-un Quiz
        [TestMethod]
        public void Test_TotalQuestions()
        {
            var quiz = new Quiz(new ExamenStrategy(), CreazaIntrebari(26), TipSesiune.Examen);
            Assert.AreEqual(26, quiz.TotalQuestions);
        }

        //verificam tipul de strategie folosit pentru un Quiz
        [TestMethod]
        public void Test_Strategy()
        {
            var strategie = new ExamenStrategy();
            var quiz = new Quiz(strategie, CreazaIntrebari(5), TipSesiune.Examen);

            Assert.IsInstanceOfType<ExamenStrategy>(quiz.Strategy);
        }

        //verificam daca se salveaza starea curenta a Quizului
        [TestMethod]
        public void Test_SaveState()
        {
            var intrebari = CreazaIntrebari(10);
            var quiz = new Quiz(new ExamenStrategy(), intrebari, TipSesiune.Examen);

            quiz.MoveToNextQuestion();
            quiz.MoveToNextQuestion();
            quiz.IncreaseScore();
            quiz.IncreaseMistakes();
            quiz.TimeRemained = TimeSpan.FromMinutes(20);

            var memento = quiz.SaveState();

            Assert.AreEqual(2, memento.CurrentIndex);
            Assert.AreEqual(1, memento.Score);
            Assert.AreEqual(1, memento.NumberOfMistakes);
            Assert.AreEqual(TimeSpan.FromMinutes(20), memento.TimeRemained);
            Assert.AreEqual(10, memento.Questions.Count);
            Assert.AreEqual(TipSesiune.Examen, memento.SessionType);
        }

        //verificam daca obiectul Quiz preia atributele cum trebuie din Memento
        [TestMethod]
        public void Test_Verifica_Restaurare_Din_Memento()
        {
            var intrebari = CreazaIntrebari(10);
            var timpSalvat = TimeSpan.FromMinutes(12);
            var memento = new QuizMemento(4, 2, 8, timpSalvat, intrebari, TipSesiune.Examen);

            var quiz = new Quiz(memento);

            Assert.AreEqual(4, quiz.CurrentIndex);
            Assert.AreEqual(2, quiz.Mistakes);
            Assert.AreEqual(8, quiz.Score);
            Assert.AreEqual(timpSalvat, quiz.TimeRemained);
            Assert.AreEqual(10, quiz.TotalQuestions);
            Assert.IsInstanceOfType<ExamenStrategy>(quiz.Strategy);
        }

    }
}
