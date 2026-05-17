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
    public partial class SignUpUserControl : UserControl
    {
        private UserRepository _userRepository;
        public SignUpUserControl()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            _userRepository = new UserRepository();

            labelError.Visible = false;
        }

        private void WriteError(string message)
        {
            labelError.Text = message;
            labelError.Visible = true;
        }
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            labelError.Visible = false;

            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
               string.IsNullOrWhiteSpace(textBoxUsername.Text) ||
               string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
               string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                WriteError("Completează toate câmpurile!");
                return;
            }

            if (textBoxUsername.Text.Length < 3 || textBoxUsername.Text.Contains(" "))
            {
                WriteError("Numele de utilizator trebuie să aibă minim 3 caractere și să nu conțină spații!");
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxEmail.Text, emailPattern))
            {
                WriteError("Te rog să introduci o adresă de email validă! (ex: nume@domeniu.com)");
                return;
            }

            if (textBoxPassword.Text.Length < 6)
            {
                WriteError("Parola trebuie să aibă cel puțin 6 caractere pentru siguranța contului tău!");
                return;
            }

            try
            {
                var allUsers = _userRepository.GetAll();
                if (allUsers.Any(u => u.Username == textBoxUsername.Text))
                {
                    WriteError("Acest utilizator este deja folosit! Conecteaza-te sau alege altul!");         
                    return;
                }

                int newId = allUsers.Any() ? allUsers.Max(u => u.Id) : 1;

                User newUser = new User(newId, textBoxName.Text, textBoxUsername.Text, textBoxEmail.Text, textBoxPassword.Text, UserRole.Utilizator);
                _userRepository.Add(newUser);

                WriteError("Cont creat cu succes! Acum te poți conecta.");

                var mainForm = (MainForm)this.ParentForm;
                mainForm.SwitchWindow(new LoginUserControl());
            }
            catch (Exception ex)
            {
                WriteError("A aparut o eroare la accesarea fisierului JSON");
            }
        }

        private void linkLabelLogIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var mainForm = (MainForm)this.ParentForm;
            mainForm.SwitchWindow(new LoginUserControl());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
