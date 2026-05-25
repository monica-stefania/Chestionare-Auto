using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace View
{
    /// <summary>
    /// Control de interfață pentru ecranul de înregistrare a unui cont nou.
    /// </summary>
    public partial class SignUpUserControl : UserControl
    {
        private UserRepository _userRepository;

        /// <summary>
        /// Inițializează controlul.
        /// </summary>
        public SignUpUserControl()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            _userRepository = UserRepository.Instance();

            labelError.Visible = false;
        }

        /// <summary>
        /// Afișează un mesaj (eroare sau confirmare) în eticheta dedicată.
        /// </summary>
        /// <param name="message">Mesajul de afișat.</param>
        private void WriteError(string message)
        {
            labelError.Text = message;
            labelError.Visible = true;
        }

        /// <summary>
        /// Gestionează click-ul pe butonul "Înregistrare".
        /// </summary>
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            labelError.Visible = false;

            // Validare câmpuri goale
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
               string.IsNullOrWhiteSpace(textBoxUsername.Text) ||
               string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
               string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                WriteError("Completează toate câmpurile!");
                return;
            }

            // Validare username: minim 3 caractere, fără spații
            if (textBoxUsername.Text.Length < 3 || textBoxUsername.Text.Contains(" "))
            {
                WriteError("Numele de utilizator trebuie să aibă minim 3 caractere și să nu conțină spații!");
                return;
            }

            // Validare format email
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxEmail.Text, emailPattern))
            {
                WriteError("Te rog să introduci o adresă de email validă! (ex: nume@domeniu.com)");
                return;
            }

            // Validare lungime minimă parolă
            if (textBoxPassword.Text.Length < 6)
            {
                WriteError("Parola trebuie să aibă cel puțin 6 caractere pentru siguranța contului tău!");
                return;
            }

            try
            {
                var allUsers = _userRepository.GetAll();
                // Verificare unicitate username
                if (allUsers.Any(u => u.Username == textBoxUsername.Text))
                {
                    WriteError("Acest utilizator este deja folosit! Conecteaza-te sau alege altul!");
                    return;
                }

                // Generare Id unic
                int newId = allUsers.Any() ? allUsers.Max(u => u.Id) + 1 : 1;

                // Creare și salvare utilizator nou cu rol implicit Utilizator
                User newUser = new User(newId, textBoxName.Text, textBoxUsername.Text, textBoxEmail.Text, textBoxPassword.Text, UserRole.Utilizator);
                _userRepository.Add(newUser);

                WriteError("Cont creat cu succes! Acum te poți conecta.");

                // Navigăm înapoi la Login
                var mainForm = (MainForm)this.ParentForm;
                mainForm.SwitchWindow(new LoginUserControl());
            }
            catch (Exception ex)
            {
                WriteError("A aparut o eroare la accesarea fisierului JSON");
            }
        }

        /// <summary>
        /// Gestionează click-ul pe link-ul "Ai deja un cont? Conectează-te".
        /// Navighează la ecranul de autentificare.
        /// </summary>
        private void linkLabelLogIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var mainForm = (MainForm)this.ParentForm;
                mainForm.SwitchWindow(new LoginUserControl());
            }
            catch (Exception ex)
            {
                WriteError("Eroare la navigare la pagina de logare.");
            }
        }

        private void SignUpUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
