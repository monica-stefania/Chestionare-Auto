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
            _userRepository = new UserRepository();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if(username == "" || password == "")
            {
                MessageBox.Show("Completati toate campurile!", "Atentie");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la accesarea fisierului JSON", "Eroare");

            }
        }

        private void linkLabelSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var mainForm = (MainForm)(this.ParentForm);
            mainForm.SwitchWindow(new SignUpUserControl());
        }
    }
}
