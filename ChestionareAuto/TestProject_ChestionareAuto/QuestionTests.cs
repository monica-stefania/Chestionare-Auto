using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_ChestionareAuto
{
    [TestClass]
    public class QuestionTests
    {
        private static Question _intrebareTest;

        //initializam un obiect Question inainte de toate testele
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _intrebareTest = new Question(
                id: 1,
                text: "Ce semnifică indicatorul triunghi roșu?",
                options: new List<string> { "Prioritate", "Pericol", "Oprire" },
                correctOptionsIndex: new List<int> { 1 },
                image: "pericol.png",
                category: "Indicatoare"
            );
        }

        //verificam fiecare parametru al unui obiect de tipul Question
        [TestMethod]
        public void Test_Parametri_Constructor_Question()
        {
            Assert.AreEqual(1, _intrebareTest.Id);
            Assert.AreEqual("Ce semnifică indicatorul triunghi roșu?", _intrebareTest.Text);
            Assert.AreEqual(3, _intrebareTest.Options.Count);
            Assert.AreEqual(1, _intrebareTest.CorrectOptionsIndex.Count);
            Assert.AreEqual(1, _intrebareTest.CorrectOptionsIndex[0]);
            Assert.AreEqual("pericol.png", _intrebareTest.Image);
            Assert.AreEqual("Indicatoare", _intrebareTest.Category);
        }

        //verificare daca obiectul Question poate avea raspunsuri multiple
        [TestMethod]
        public void Test_Raspunsuri_Multiple_Question()
        {
            var q = new Question(
                id: 2,
                text: "Care vehicule au prioritate?",
                options: new List<string> { "Ambulanța", "Mașina personală", "Pompierii" },
                correctOptionsIndex: new List<int> { 0, 2 },
                image: "",
                category: "Prioritate"
            );

            Assert.AreEqual(2, q.CorrectOptionsIndex.Count);
            CollectionAssert.Contains(q.CorrectOptionsIndex, 0);
            CollectionAssert.Contains(q.CorrectOptionsIndex, 2);
        }

        //verificam cazul in care utilizatorul da raspunsul corect la intrebare
        [TestMethod]
        public void Test_Verificare_Raspuns_Corect_De_La_User()
        {
            int raspunsUtilizator = 1;
            bool esteCorect = _intrebareTest.CorrectOptionsIndex.Contains(raspunsUtilizator);
            Assert.IsTrue(esteCorect);
        }

        //verificam cazul in care utilizatorul da raspunsul gresit la intrebare
        [TestMethod]
        public void Test_Verificare_Raspuns_Gresit_De_La_User()
        {
            int raspunsGresit = 0;
            bool esteCorect = _intrebareTest.CorrectOptionsIndex.Contains(raspunsGresit);
            Assert.IsFalse(esteCorect);
        }
    }
}
