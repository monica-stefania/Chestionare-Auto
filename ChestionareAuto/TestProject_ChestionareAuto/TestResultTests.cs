using Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace TestProject_ChestionareAuto
{
    [TestClass]
    public class TestResultTests
    {
        //verificam daca starea testului e admis sau nu dupa 22 de raspunsuri corecte
        [TestMethod]
        public void Test_Stare_Chestionar_Admis()
        {
            var result = new Entities.TestResult(1, 1, DateTime.Now, 22, TipSesiune.Examen, StareTest.Admis);
            Assert.IsTrue(result.IsPassed());
        }

        //verificam daca starea testului e respins sau nu dupa 10 de raspunsuri corecte
        [TestMethod]
        public void Test_Stare_Chestionar_Respins()
        {
            var result = new Entities.TestResult(2, 1, DateTime.Now, 10, TipSesiune.Examen, StareTest.Respins);
            Assert.IsFalse(result.IsPassed());
        }

        //verificam daca starea testului e respins sau nu daca userul incheie sesiunea pentru a o continua mai tarziu (trebuie sa returneze false)
        [TestMethod]
        public void Test_Stare_Chestionar_Nefinalizat()
        {
            var result = new Entities.TestResult(3, 1, DateTime.Now, 0, TipSesiune.Examen, StareTest.Nefinalizat);
            Assert.IsFalse(result.IsPassed());
        }

        [TestMethod]
        public void Test_Constructor_Default()
        {
            var result = new Entities.TestResult();
            Assert.IsNotNull(result);
        }

        //verificam daca starea chestionarului se salveaza cu succes  daca userul incheie sesiunea pentru a o continua mai tarziu cu ajutorul design patternului Memento 
        [TestMethod]
        public void Test_Stare_Chestionar_Salvata()
        {
            var memento = new QuizMemento();
            var result = new Entities.TestResult(1, 1, DateTime.Now, 5, TipSesiune.Invatare, StareTest.Nefinalizat, memento);

            Assert.IsNotNull(result.DateSalvate);
            Assert.AreSame(memento, result.DateSalvate);
        }

        //verificam tipul de sesiune (putem avea mediu de invatare si examen)
        [TestMethod]
        public void Test_Tip_Sesiune()
        {
            var resultExamen = new Entities.TestResult(1, 1, DateTime.Now, 22, TipSesiune.Examen, StareTest.Admis);
            var resultInvatare = new Entities.TestResult(2, 1, DateTime.Now, 5, TipSesiune.Invatare, StareTest.Nefinalizat);

            Assert.AreEqual(TipSesiune.Examen, resultExamen.SessionType);
            Assert.AreEqual(TipSesiune.Invatare, resultInvatare.SessionType);
        }
    }
}
