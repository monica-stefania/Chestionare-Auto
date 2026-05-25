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
    public partial class LoginUserControl : UserControl
    {
        private UserRepository _userRepository;
        public LoginUserControl()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            _userRepository = UserRepository.Instance();
            labelError.Visible = false;
        }
        private void WriteError(string message)
        {
            labelError.Text = message;
            labelError.Visible = true;
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            labelError.Visible = false;
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

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
                    QuizManager.Instance.CurrentUser = findUser;
                    var mainForm = (MainForm)this.ParentForm;

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

        private void linkLabelSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var mainForm = (MainForm)(this.ParentForm);
            mainForm.SwitchWindow(new SignUpUserControl());
        }

        private void LoginUserControl_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
