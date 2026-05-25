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
    public class ExamenStrategyTests
    {
        private static ExamenStrategy _strategy;

        //initializam un obiect ExamenStrategy inainte de a rula testele
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
           _strategy = new ExamenStrategy();
        }

        //verificam daca trebuie dat imediat raspunsul dupa fiecare intrebare (in modul de invatare trebuie dat imediat, in cel de examen nu)
        [TestMethod]
        public void Test_ShowImmediateFeedback()
        {
            Assert.IsFalse(_strategy.ShowImmediateFeedback());
        }

        //verificam daca are timp (in modul de invatare nu avem, in cel de examen avem)
        [TestMethod]
        public void Test_HasTimeLimit()
        {
            Assert.IsTrue(_strategy.HasTimeLimit());
        }

        //un test de tipul examen trebuie sa dureze 30 de minute
        [TestMethod]
        public void Test_GetTimeLimit()
        {
            // 30 minute = 1800 secunde
            Assert.AreEqual(1800, _strategy.GetTimeLimit());
        }

        //numarul maxim de raspunsuri gresite per test poate fi 5
        [TestMethod]
        public void Test_GetMaximumMistakes()
        {
            Assert.AreEqual(5, _strategy.GetMaximumMistakes());
        }
    }
}
