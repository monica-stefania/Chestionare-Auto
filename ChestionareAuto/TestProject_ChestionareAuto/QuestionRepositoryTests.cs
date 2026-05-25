using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace TestProject_ChestionareAuto
{
    [TestClass]
    public class QuestionRepositoryTests
    {
        private List<Question> _intrebari;
        //initializam lista de intrebari
        [TestInitialize]
        public void Initialize()
        {
            _intrebari = new List<Question>
            {
                new Question(1, "Q1?", new List<string>{"A","B"}, new List<int>{0}, "", "Semne"),
                new Question(2, "Q2?", new List<string>{"A","B"}, new List<int>{1}, "", "Semne"),
                new Question(3, "Q3?", new List<string>{"A","B"}, new List<int>{0}, "", "Reguli"),
                new Question(4, "Q4?", new List<string>{"A","B"}, new List<int>{0}, "", "Reguli"),
                new Question(5, "Q5?", new List<string>{"A","B"}, new List<int>{1}, "", "Semne")
            };
        }

        [TestMethod]
        public void Test_Delete_Question()
        {
            var stergeIntrebare = _intrebari.FirstOrDefault(q => q.Id == 3);
            _intrebari.Remove(stergeIntrebare);

            Assert.AreEqual(4, _intrebari.Count);
        }

        [TestMethod]
        public void Test_Add_Question()
        {
            var intrebareNoua = new Question(6, "Q6?", new List<string> { "A", "B"}, new List<int> { 0 }, "", "Conducere preventiva");
            _intrebari.Add(intrebareNoua);

            Assert.AreEqual(6, _intrebari.Count);
        }
    }
}
