using Entities;
using Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_ChestionareAuto
{
    [TestClass]
    public class QuizMementoTests
    {
        private List<Question> CreazaListaIntrebari(int numar = 3)
        {
            var lista = new List<Question>();
            for (int i = 0; i < numar; i++)
                lista.Add(new Question(i + 1, $"Întrebare {i + 1}?",
                    new List<string> { "A", "B", "C" },
                    new List<int> { 0 }, "", "General"));
            return lista;
        }

        //testare parametri constructor
        [TestMethod]
        public void Test_Constructor_Cu_Parametri()
        {
            //lista cu intrebari ale testului
            var intrebari = CreazaListaIntrebari(5);
            //timpul ramas din test
            var timp = TimeSpan.FromMinutes(15);

            var memento = new QuizMemento(3, 2, 10, timp, intrebari, TipSesiune.Examen);

            Assert.AreEqual(3, memento.CurrentIndex);
            Assert.AreEqual(2, memento.NumberOfMistakes);
            Assert.AreEqual(10, memento.Score);
            Assert.AreEqual(timp, memento.TimeRemained);
            Assert.AreEqual(5, memento.Questions.Count);
            Assert.AreEqual(TipSesiune.Examen, memento.SessionType);
            Assert.AreSame(intrebari, memento.Questions);
        }

        // verificam daca se creaza automat lista de intrebari a mementoului pt constructorul fara parametri
        [TestMethod]
        public void Test_Constructor_Fara_Parametri()
        {
            var memento = new QuizMemento();
            Assert.IsNotNull(memento.Questions);
            Assert.AreEqual(0, memento.Questions.Count);
        }

        //verificam daca se pastreaza corect timpul ramas din test
        [TestMethod]
        public void Test_Pastrare_Timp_Ramas()
        {
            // 15 minute rămase
            var timpRamas = TimeSpan.FromSeconds(900); 
            var memento = new QuizMemento(5, 1, 15, timpRamas, new List<Question>(), TipSesiune.Examen);

            Assert.AreEqual(900, memento.TimeRemained.TotalSeconds);
        }

    }
}
