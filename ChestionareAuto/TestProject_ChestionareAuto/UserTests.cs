using Entities;

namespace TestProject_ChestionareAuto
{
    [TestClass]
    public class UserTests
    {

        //testare parametri atunci cand initializam un nou obiect de tip User
        [TestMethod]
        public void Test_Parametri_Constructor_User()
        {
            var user = new User(5, "Ion Popescu", "ionp", "ion@email.com", "parola123", UserRole.Utilizator);

            Assert.AreEqual(5, user.Id);
            Assert.AreEqual("Ion Popescu", user.Name);
            Assert.AreEqual("ionp", user.Username);
            Assert.AreEqual("ion@email.com", user.Email);
            Assert.AreEqual("parola123", user.Password);
            Assert.AreEqual(UserRole.Utilizator, user.Role);
        }

        //testare rol de admin al userului
        [TestMethod]
        public void Test_Rol_Admin()
        {
            var admin = new User(1, "Admin", "admin", "admin@email.com", "admin", UserRole.Admin);
            Assert.AreEqual(UserRole.Admin, admin.Role);
        }

        //testare rol de utilizator al userului
        [TestMethod]
        public void Test_Rol_Utilizator()
        {
            var user = new User(3, "Ion Popescu", "ionp", "ion@email.com", "parola123", UserRole.Utilizator);
            Assert.AreEqual(UserRole.Utilizator, user.Role);
        }

        //testare schimbare parametri al unui user curent
        [TestMethod]
        public void Test_Schimbare_Proprietati_User()
        {
            var user = new User(1, "Vechi Nume", "vechi", "vechi@email.com", "vechi", UserRole.Utilizator);

            user.Name = "Nou Nume";
            user.Email = "nou@email.com";
            user.Role = UserRole.Admin;

            Assert.AreEqual("Nou Nume", user.Name);
            Assert.AreEqual("nou@email.com", user.Email);
            Assert.AreEqual(UserRole.Admin, user.Role);
        }
    }
}
