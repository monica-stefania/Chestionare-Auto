using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_ChestionareAuto
{
    [TestClass]
    public class UserRepositoryTests
    {
        private List<User> _users;
        //initializam lista de useri
        [TestInitialize]
        public void Initialize()
        {
            _users = new List<User>
            {
                new User(1, "Existent", "ex", "ex@ex.com", "p", UserRole.Utilizator),
                new User(2, "Existent2", "ex2", "ex2@ex.com", "p", UserRole.Utilizator)
            };
        }


        //testam logica de adaugare a userilor
        [TestMethod]
        public void Test_User_Add()
        {
            var userNou = new User(0, "Test User", "testuser", "test@test.com", "pass", UserRole.Utilizator);

            // Simulăm logica din Add()
            userNou.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(userNou);

            Assert.AreEqual(3,_users.Count);
            Assert.AreEqual(3, _users[_users.Count - 1].Id);
        }

        //testam stergerea userului 
        [TestMethod]
        public void Test_User_Delete()
        {

            var deSters = _users.FirstOrDefault(u => u.Id == 1);
            _users.Remove(deSters);

            Assert.AreEqual(1,_users.Count);
            Assert.AreEqual(2, _users[0].Id);
        }

        //veriifcam daca sunt salvate modificarile facute la un user
        [TestMethod]
        public void Test_User_Update()
        {

            var dateNoi = new User(2, "Nou Nume", "nounume", "nou@v.com", "newpass", UserRole.Admin);
            var existent = _users.FirstOrDefault(u => u.Id == dateNoi.Id);
            if (existent != null)
            {
                existent.Name = dateNoi.Name;
                existent.Username = dateNoi.Username;
                existent.Email = dateNoi.Email;
                existent.Password = dateNoi.Password;
                existent.Role = dateNoi.Role;
            }

            Assert.AreEqual("Nou Nume", _users[1].Name);
            Assert.AreEqual("nounume", _users[1].Username);
            Assert.AreEqual(UserRole.Admin, _users[1].Role);
        }

    }
}
