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
    public class QuizManagerTests
    {
        //poate exista o singura instanta de tipul QuizManager
        [TestMethod]
        public void Test_QuizManager_Instance()
        {
            var instance1 = QuizManager.Instance;
            var instance2 = QuizManager.Instance;

            Assert.AreSame(instance1, instance2);
        }

        //setam userul curent
        [TestMethod]
        public void Test_QuizManager_CurrentUser()
        {
            var user = new User(1, "Test", "test", "test@test.com", "pass", UserRole.Utilizator);
            QuizManager.Instance.CurrentUser = user;

            Assert.AreEqual(user, QuizManager.Instance.CurrentUser);
        }

        //setam quizul 
        [TestMethod]
        public void Test_QuizManager_ActiveQuiz()
        {
            var quiz = new Quiz(new PracticeStrategy(),
                new List<Question> { new Question(1, "Intrebare 1?", new List<string> { "A", "B", "C" }, new List<int> { 0 }, "", "General") },TipSesiune.Invatare);

            QuizManager.Instance.ActiveQuiz = quiz;

            Assert.IsNotNull(QuizManager.Instance.ActiveQuiz);
        }

        [TestMethod]
        public void Test_QuizManager_ActiveResultId()
        {
            QuizManager.Instance.ActiveResultId = 0;
            Assert.AreEqual(0, QuizManager.Instance.ActiveResultId);
        }
    }
}
