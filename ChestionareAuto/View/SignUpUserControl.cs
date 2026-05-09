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
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if(textBoxPassword.Text == "" || textBoxName.Text == "" || textBoxEmail.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Completeaza toate campurile! ", "Atentie");
                return;
            }

            try
            {
                var allUsers = _userRepository.GetAll();
                if (allUsers.Any(u => u.Username == textBoxUsername.Text))
                {
                    MessageBox.Show("Acest utilizator este deja folosit! Conecteaza-te sau alege altul!", "Eroare");
                    return;
                }

                int newId = allUsers.Any() ? allUsers.Max(u => u.Id) : 1;

                User newUser = new User(newId, textBoxName.Text, textBoxUsername.Text, textBoxEmail.Text, textBoxPassword.Text, UserRole.Utilizator);
                _userRepository.Add(newUser);

                MessageBox.Show("Cont creat cu succes! Acum te poți conecta.", "Succes");

                var mainForm = (MainForm)this.ParentForm;
                mainForm.SwitchWindow(new LoginUserControl());
            }
            catch (Exception ex)
            {
                MessageBox.Show("A aparut o eroare la accesarea fisierului JSON", "Eroare");
            }
        }

        private void linkLabelLogIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var mainForm = (MainForm)this.ParentForm;
            mainForm.SwitchWindow(new LoginUserControl());
        }
    }
}
