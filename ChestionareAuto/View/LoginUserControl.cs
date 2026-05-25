using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Patterns;
using Repositories;

namespace View
{
    /// <summary>
    /// Control de interfață pentru ecranul de logare.
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        private UserRepository _userRepository;

        /// <summary>
        /// Inițializează controlul.
        /// </summary>
        public LoginUserControl()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            _userRepository = UserRepository.Instance();
            labelError.Visible = false;
        }

        /// <summary>
        /// Afișează un mesaj de eroare în eticheta dedicată și o face vizibilă.
        /// </summary>
        /// <param name="message">Mesajul de eroare de afișat.</param>
        private void WriteError(string message)
        {
            labelError.Text = message;
            labelError.Visible = true;
        }

        /// <summary>
        /// Gestionează evenimentul de click pe butonul "Login".
        /// </summary>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            labelError.Visible = false;
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            
            // Validare câmpuri goale
            if (username == "" || password == "")
            {
                WriteError("Completati toate campurile!");
                return;
            }
            try
            {
                var allUsers = _userRepository.GetAll();
                var findUser = allUsers.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (findUser != null)
                {
                    // Setăm utilizatorul curent în Singleton-ul QuizManager
                    QuizManager.Instance.CurrentUser = findUser;
                    var mainForm = (MainForm)this.ParentForm;

                    // Navigăm la dashboard-ul corespunzător rolului
                    if (findUser.Role == Entities.UserRole.Admin)
                    {
                        mainForm.SwitchWindow(new DashboardAdminControl());
                    }
                    else
                    {
                        mainForm.SwitchWindow(new DashboardUserControl());
                    }
                }
                else
                {
                    WriteError("Utilizator sau parola gresite!");
                    return;
                }
            }
            catch (Exception ex)
            {
                WriteError("Eroare la accesarea fisierului JSON");

            }
        }

        /// <summary>
        /// Gestionează click-ul pe link-ul "Creează un cont".
        /// Navighează la ecranul de înregistrare.
        /// </summary>
        private void linkLabelSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var mainForm = (MainForm)(this.ParentForm);
                mainForm.SwitchWindow(new SignUpUserControl());
            }
            catch (Exception ex)
            {
                WriteError("Eroare la navigare la pagina de înregistrare.");
            }
        }

        private void LoginUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
