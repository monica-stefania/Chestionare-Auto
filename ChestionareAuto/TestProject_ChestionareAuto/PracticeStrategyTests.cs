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
    public class PracticeStrategyTests
    {
        private static PracticeStrategy _strategy;

        //initializam un obiect ExamenStrategy inainte de a rula testele
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _strategy = new PracticeStrategy();
        }

        //verificam daca trebuie dat imediat raspunsul dupa fiecare intrebare (in modul de invatare trebuie dat imediat, in cel de examen nu)
        [TestMethod]
        public void Test_ShowImmediateFeedback()
        {
            Assert.IsTrue(_strategy.ShowImmediateFeedback());
        }

        //verificam daca are timp (in modul de invatare nu avem, in cel de examen avem)
        [TestMethod]
        public void Test_HasTimeLimit()
        {
            Assert.IsFalse(_strategy.HasTimeLimit());
        }

        //un test de tipul invatare nu are timp limita
        [TestMethod]
        public void Test_GetTimeLimit()
        {
            // 30 minute = 1800 secunde
            Assert.AreEqual(0, _strategy.GetTimeLimit());
        }

        //nu exista numar de raspunsuri gresite pt modul invatare
        [TestMethod]
        public void Test_GetMaximumMistakes()
        {
            Assert.AreEqual(int.MaxValue, _strategy.GetMaximumMistakes());
        }
    }
}
